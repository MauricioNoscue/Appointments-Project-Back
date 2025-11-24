using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel.Services;
using Data_Back;
using Entity_Back.Context;
using Entity_Back;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Data_Back.Interface.IDataModels.Security;

namespace Business_Back.Services.Citation
{
    /// <summary>
    /// Servicio encargado de reagendar citas médicas buscando el siguiente bloque horario disponible.
    /// </summary>
    public class CitationReschedulerService : ICitationReschedulerService
    {
        private readonly IScheduleHourBusiness _scheduleHourBusiness;
        private readonly ISheduleBusiness _sheduleBusiness;
        private readonly ICitationsBusiness _citationBusiness;
        private readonly IUserData _userData;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<CitationReschedulerService> _logger;
        private readonly ICitationNotificationService _citationNotification;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CitationReschedulerService"/>.
        /// </summary>
        /// <param name="shBusiness">Servicio de gestión de horas de horario.</param>
        /// <param name="sBusiness">Servicio de gestión de horarios.</param>
        /// <param name="citationBussines">Servicio de gestión de citas.</param>
        /// <param name="db">Contexto de base de datos.</param>
        /// <param name="userData">Servicio de gestión de usuarios.</param>
        /// <param name="logger">Logger para la clase.</param>
        /// <param name="citationNotification">Servicio de notificación de citas.</param>
        public CitationReschedulerService(
            IScheduleHourBusiness shBusiness,
            ISheduleBusiness sBusiness,
            ICitationsBusiness citationBussines,
            ApplicationDbContext db,
            IUserData userData,
            ILogger<CitationReschedulerService> logger,
            ICitationNotificationService citationNotification)
        {
            _scheduleHourBusiness = shBusiness;
            _sheduleBusiness = sBusiness;
            _citationBusiness = citationBussines;
            _db = db;
            _logger = logger;
            _userData = userData;
            _citationNotification = citationNotification;
        }

        /// <summary>
        /// Intenta reagendar una cita buscando el siguiente bloque horario disponible en los próximos 10 días.
        /// </summary>
        /// <param name="original">La cita original a reagendar.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>La nueva cita reagendada o null si no fue posible reagendar.</returns>
        public async Task<Entity_Back.Citation?> TryRescheduleAsync(Entity_Back.Citation original, CancellationToken ct)
        {
            try
            {
                TimeSpan horaOriginal = original.TimeBlock!.Value;
                DateTime fechaOriginal = original.AppointmentDate.Date;

                // 🚀 Doctor real de la cita (esto YA VIENE desde el Include del handler)
                int doctorId = original.ScheduleHour.Shedule.DoctorId;

                // Iterar por los próximos 10 días
                for (int i = 1; i <= 10; i++)
                {
                    var dia = fechaOriginal.AddDays(i); // siguiente día

                    // ⚠️ No filtrar por fecha. La agenda es fija.
                    var shedule = await _sheduleBusiness.GetByDoctorAndDateAsync(doctorId, dia);
                    if (shedule == null) continue;

                    // Obtener las horas configuradas del horario base
                    var scheduleHour = await _scheduleHourBusiness.GetByDateAndSheduleAsync(shedule.Id);
                    if (scheduleHour == null) continue;

                    // Calcular bloques horarios disponibles
                    var todos = new CitationCoreService(
                        _scheduleHourBusiness,
                        _sheduleBusiness,
                        _citationBusiness
                    ).CalcularBloquesHorarios(scheduleHour.Adapt<ScheduleHour>());

                    var usados = await _citationBusiness
                        .GetUsedTimeBlocksByScheduleHourIdAndDateAsync(scheduleHour.Id, dia);

                    TimeSpan? bloqueSeleccionado = null;

                    // Preferir el mismo bloque si está libre
                    if (!usados.Contains(horaOriginal))
                    {
                        bloqueSeleccionado = horaOriginal;
                    }
                    else
                    {
                        bloqueSeleccionado = todos
                            .Where(b => !usados.Contains(b))
                            .OrderBy(b => Math.Abs((b - horaOriginal).TotalMinutes))
                            .FirstOrDefault();
                    }

                    if (bloqueSeleccionado == null)
                        continue; // no había nada ese día, probar siguiente día

                    // Crear la nueva cita reprogramada
                    var nueva = new Entity_Back.Citation
                    {
                        UserId = original.UserId,
                        AppointmentDate = dia,
                        TimeBlock = bloqueSeleccionado,
                        StatustypesId = 1, // programada
                        ScheduleHourId = scheduleHour.Id,
                        Note = original.Note,
                        IsDeleted = false,
                        RegistrationDate = DateTime.UtcNow
                    };

                    _db.Set<Entity_Back.Citation>().Add(nueva);

                    // Cambiar estado de la original a cancelada
                    original.StatustypesId = 10;
                    original.AppointmentDate = nueva.AppointmentDate;
                    original.TimeBlock = nueva.TimeBlock;
                    _db.Entry(original).State = EntityState.Modified;

                    await _citationNotification.SendCitationConfirmationAsync(original, ct);

                    await _db.SaveChangesAsync(ct);
                    var user = await _userData.GetById(original.UserId);
                    await _citationNotification.SendCitationConfirmationAsync(nueva, ct);

                    return nueva; // éxito
                }

                return null; // no se pudo reprogramar en 10 días
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar reagendar la cita.");
                throw;
            }
        }
    }

}
