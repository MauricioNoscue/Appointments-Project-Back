using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel.Services;
using Data_Back.Interface.IDataModels.Security;
using Data_Back;
using Entity_Back.Context;
using Entity_Back.Models.Request;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;
using Business_Back.Interface.IBusinessModel;
using Microsoft.EntityFrameworkCore;

namespace Business_Back.Services.Citation
{
    /// <summary>
    /// Handler encargado de procesar solicitudes de ausencia de un doctor.
    /// Gestiona la reprogramación o cancelación de citas según la configuración de los usuarios afectados.
    /// Utiliza servicios de datos de citas, usuarios y reprogramación, así como el contexto de base de datos y logging.
    /// </summary>
    public class DoctorAbsenceRequestHandler : IModificationRequestHandler
    {
        private readonly ICitationsData _citationsData;
        private readonly IUserData _userData;
        private readonly ICitationReschedulerService _rescheduler;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DoctorAbsenceRequestHandler> _logger;
        private readonly ICitationNotificationService _citationNotification;


        /// <summary>
        /// Constructor de la clase DoctorAbsenceRequestHandler.
        /// Inicializa las dependencias necesarias para el manejo de ausencias de doctores.
        /// </summary>
        /// <param name="citationsData">Servicio de datos de citas.</param>
        /// <param name="userData">Servicio de datos de usuarios.</param>
        /// <param name="rescheduler">Servicio de reprogramación de citas.</param>
        /// <param name="db">Contexto de base de datos.</param>
        /// <param name="logger">Logger para registrar información y errores.</param>
        public DoctorAbsenceRequestHandler(
            ICitationsData citationsData,
            IUserData userData,
            ICitationReschedulerService rescheduler,
            ApplicationDbContext db,
            ILogger<DoctorAbsenceRequestHandler> logger,
            ICitationNotificationService citationNotification)
        {
            _citationsData = citationsData;
            _userData = userData;
            _rescheduler = rescheduler;
            _db = db;
            _logger = logger;
            _citationNotification = citationNotification;
        }

        /// <summary>
        /// Procesa la solicitud de ausencia de un doctor.
        /// Obtiene las citas del doctor en la fecha indicada y decide si reprogramarlas o cancelarlas
        /// según la configuración de cada usuario afectado.
        /// </summary>
        /// <param name="request">Solicitud de modificación que indica la ausencia del doctor.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task HandleAsync(ModificationRequest request)
        {
            try
            {
                if (request.StartDate == null)
                    throw new BusinessException("StartDate is required for doctor absence.");

                DateTime fecha = request.StartDate.Value.Date;

                // 🔥 NUEVO: detectar si el usuario realmente es doctor
                int doctorId = request.UserId;

                var doctorReal = await GetDoctorIdFromUserAsync(request.UserId);
                if (doctorReal != null)
                    doctorId = doctorReal.Value; // usar el doctor asociado a la persona

                // 1. Obtener citas del doctor en esa fecha (con doctorId REAL)
                var citas = await _citationsData
                    .GetCitationsByDoctorAndDate(doctorId, fecha);

                if (!citas.Any())
                    return;

                foreach (var cita in citas)
                {
                    var user = await _userData.GetById(cita.UserId);
                    bool autoReprog = user?.Rescheduling ?? false;

                    if (autoReprog)
                    {
                        await ReprogramAsync(cita);
                    }
                    else
                    {
                        await CancelAsync(cita);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de ausencia del doctor.");
                throw;
            }
        }

        /// <summary>
        /// Reprograma una cita si es posible. Si no se puede reprogramar, la cancela.
        /// Utiliza una transacción para asegurar la consistencia de los datos.
        /// </summary>
        /// <param name="cita">La cita a reprogramar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task ReprogramAsync(Entity_Back.Citation cita)
        {
            try
            {
                using var tx = await _db.Database.BeginTransactionAsync();

                try
                {
                    var newCitation = await _rescheduler.TryRescheduleAsync(cita, CancellationToken.None);

                    if (newCitation == null)
                    {
                        cita.StatustypesId = 2; // Cancelada
                        _db.Entry(cita).State = EntityState.Modified;
                        await _db.SaveChangesAsync();
                    }

                    await tx.CommitAsync();

                    // HOOK PARA WEBSOCKET
                    // await _events.CitationReprogrammed(cita.Id);
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    _logger.LogError(ex, "Error reprogramming citation.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error general al reprogramar la cita.");
                throw;
            }
        }

        /// <summary>
        /// Cancela una cita estableciendo su estado como cancelada.
        /// </summary>
        /// <param name="cita">La cita a cancelar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task CancelAsync(Entity_Back.Citation cita)
        {
            try
            {
                cita.StatustypesId = 2;
                _db.Entry(cita).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                CancellationToken ct = CancellationToken.None;

                await _citationNotification.SendCitationConfirmationAsync(cita, ct);

                // HOOK WEBSOCKET
                // await _events.CitationCancelled(cita.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cancelar la cita.");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el DoctorId real asociado al UserId.
        /// Si el usuario no es doctor, retorna null.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>El identificador del doctor si existe, de lo contrario null.</returns>
        private async Task<int?> GetDoctorIdFromUserAsync(int userId)
        {
            try
            {
                // Obtener el usuario
                var user = await _userData.GetById(userId);
                if (user == null) return null;

                // Obtener la persona del usuario
                int personId = (int)user.PersonId;

                // Buscar el doctor asociado a esa persona
                var doctor = await _db.Doctors
                    .Where(d => d.PersonId == personId && !d.IsDeleted)
                    .Select(d => d.Id)
                    .FirstOrDefaultAsync();

                return doctor == 0 ? null : doctor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el DoctorId real desde el UserId.");
                throw;
            }
        }

    }

}
