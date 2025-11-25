using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Business_Back.Services.Notification;
using Business_Back.Services.Notification.Fabric;
using Data_Back;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Enum;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back
{
    /// <summary>
    /// Lógica de negocio para la gestión de citas médicas.
    /// </summary>
    public class CitationBusiness : BaseModelBusinessIm<Citation, CitationCreateDto, CitationEditDto, CitationListDto>, ICitationsBusiness
    {
        private readonly ICitationsData _data;
        private readonly IUserData _userBusiness;
        private readonly INotificationOrchestrator _orchestrator;
        private readonly IUserBusiness _userService;

        /// <summary>
        /// Constructor de la clase CitationBusiness.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="data">Acceso a datos de citas.</param>
        /// <param name="logger">Logger para trazabilidad.</param>
        /// <param name="userBusiness">Acceso a datos de usuario.</param>
        /// <param name="orchestrator">Orquestador de notificaciones.</param>
        /// <param name="userService">Servicio de usuario.</param>
        public CitationBusiness(IConfiguration configuration, ICitationsData data, ILogger<CitationBusiness> logger,
             IUserData userBusiness, INotificationOrchestrator orchestrator, IUserBusiness userService)
            : base(configuration, data, logger)
        {
            _data = data;
            _userBusiness = userBusiness;
            _orchestrator = orchestrator;
            _userService = userService;
        }

        /// <summary>
        /// Obtiene los bloques de tiempo ya utilizados para un horario y fecha específicos.
        /// </summary>
        /// <param name="scheduleHourId">Id del horario.</param>
        /// <param name="appointmentDate">Fecha de la cita.</param>
        /// <returns>Lista de bloques de tiempo ocupados.</returns>
        public Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate)
        {
            try
            {
                return _data.GetUsedTimeBlocksByScheduleHourIdAndDateAsync(scheduleHourId, appointmentDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetUsedTimeBlocksByScheduleHourIdAndDateAsync");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las citas para un usuario específico en formato de lista.
        /// </summary>
        /// <param name="UserId">Id del usuario.</param>
        /// <returns>Lista de citas.</returns>
        public async Task<List<CitationListDto>> GetAllForListAsync(int UserId)
        {
            try
            {
                var Citations = await _data.GetAllForListAsync(UserId);
                return Citations.Adapt<List<CitationListDto>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetAllForListAsync");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una cita existente.
        /// </summary>
        /// <param name="dto">DTO con los datos a actualizar.</param>
        /// <returns>True si la actualización fue exitosa.</returns>
        public override async Task<bool> Update(CitationEditDto dto)
        {
            try
            {
                if (dto == null) throw new ValidationException(nameof(dto), "Datos inválidos");

                var entity = await _data.GetById(dto.Id);
                if (entity is null) throw new EntityNotFoundException($"Citation {dto.Id} no existe");

                // Hacemos merge del DTO hacia la entidad (solo campos presentes)
                dto.Adapt(entity);

                var updated = await _data.Update(entity);
                if (!updated) return false;

                // Enviar correo y notificación según el estado nuevo:
                await SendCitationStatusNotificationAsync(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando Citation {CitationId}", dto?.Id);
                throw;
            }
        }

        /// <summary>
        /// Envía notificaciones y correos electrónicos según el estado de la cita.
        /// </summary>
        /// <param name="citation">Entidad de cita.</param>
        private async Task SendCitationStatusNotificationAsync(Entity_Back.Citation citation)
        {
            try
            {
                var user = await _userBusiness.GetById(citation.UserId);
                if (user == null) return;

                (string subject, string body) email;
                (string title, string message, TypeNotification type, int statusId) notification;

                switch (citation.StatustypesId)
                {


                    case 2: // cancelada
                        email = EmailTemplateFactory.BuildCitationCanceled(user, citation);
                        notification = NotificationFactory.BuildCitationCanceled();
                        break;

                    case 3: // No asistida
                        email = EmailTemplateFactory.BuildCitationMissed(user, citation);
                        notification = NotificationFactory.BuildCitationMissed();
                        await _userService.UpdateRestrictionPointsAsync(user.Id);
                        break;

                    case 4: // Atendida
                        email = EmailTemplateFactory.BuildCitationCompleted(user, citation);
                        notification = NotificationFactory.BuildCitationCompleted();
                        break;

                    default:
                        return; // No enviamos nada para otros estados
                }

                await _orchestrator.SendAsync(new UnifiedNotificationDto
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Subject = email.subject,
                    Body = email.body,
                    NotificationTitle = notification.title,
                    NotificationMessage = notification.message,
                    TypeNotification = notification.type,
                    StatusTypesId = notification.statusId

                }, CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en SendCitationStatusNotificationAsync para la cita {CitationId}", citation?.Id);
                throw;
            }
        }


       
     
        public  async Task<IEnumerable<CitationListDto>> GetCitationsByDoctor(int doctorId, DateTime date)
        {
            try
            {
                var allEntities = await _data.GetCitationsByDoctor(doctorId,date);
                return allEntities.Adapt<IEnumerable<CitationListDto>>();

            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, $"Error al obtener los reguistros registros  ");
                throw new BusinessException("Ocurrió un error inesperado al consultar los datos.", ex);
            }
        }
    }

}

