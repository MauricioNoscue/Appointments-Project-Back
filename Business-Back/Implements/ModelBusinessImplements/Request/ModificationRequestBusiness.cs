using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.IBusinessModel;
using Business_Back.Interface.IBusinessModel.Request;
using Business_Back.Interface.IBusinessModel.Security;
using Business_Back.Services.Notification;
using Business_Back.Services.Notification.Fabric;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Request;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Dto.RequestDto;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Entity_Back.Enum;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back.Implements.ModelBusinessImplements.Request
{
    /// <summary>
    /// Implementación de la lógica de negocio para la gestión de solicitudes de modificación.
    /// Hereda de <see cref="BaseModelBusinessIm{ModificationRequest, ModificationRequestCreateDto, ModificationRequestEditDto, ModificationRequestListDto}"/>
    /// e implementa <see cref="IModificationRequestBusiness"/>.
    /// </summary>
    public class ModificationRequestBusiness : BaseModelBusinessIm<ModificationRequest, ModificationRequestCreateDto, ModificationRequestEditDto, ModificationRequestListDto>, IModificationRequestBusiness
    {
        private readonly IModificationRequestData _data;
        private readonly IModificationRequestHandler _doctorAbsenceHandler;
        private readonly IUserData _userBusiness;
        private readonly INotificationOrchestrator _orchestrator;
        private readonly IUserBusiness _userService;

        /// <summary>
        /// Constructor de la clase <see cref="ModificationRequestBusiness"/>.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="data">Acceso a datos de solicitudes de modificación.</param>
        /// <param name="logger">Logger para registrar eventos y errores.</param>
        /// <param name="doctorAbsenceHandler">Manejador de ausencias de doctor.</param>
        /// <param name="userBusiness">Acceso a datos de usuario.</param>
        /// <param name="orchestrator">Orquestador de notificaciones.</param>
        public ModificationRequestBusiness(IConfiguration configuration, IModificationRequestData data,
            ILogger<ModificationRequestBusiness> logger,
            IModificationRequestHandler doctorAbsenceHandler, IUserData userBusiness, INotificationOrchestrator orchestrator, IUserBusiness userService)
            : base(configuration, data, logger)
        {
            _data = data;
            _doctorAbsenceHandler = doctorAbsenceHandler;
            _userBusiness = userBusiness;
            _orchestrator = orchestrator;
            _userService = userService;
        }

        /// <summary>
        /// Actualiza el estado de una solicitud de modificación y ejecuta acciones asociadas según el nuevo estado.
        /// </summary>
        /// <param name="id">Identificador de la solicitud.</param>
        /// <param name="statusTypeId">Identificador del nuevo estado.</param>
        /// <param name="restore">Indica si se debe restaurar (opcional).</param>
        /// <returns>True si la actualización fue exitosa; de lo contrario, false.</returns>
        public override async Task<bool> UpdateStatusTypesAsync(int id, int statusTypeId, bool? restore = false)
        {
            try
            {
                // 1. Actualizar estado
                var updated = await _data.UpdateStatusTypesAsync(id, statusTypeId);
                if (!updated) return false;

                // 2. Obtener request
                var request = await _data.GetById(id);
                if (request == null)
                    throw new BusinessException("ModificationRequest not found.");

                // 3. Ejecutar envío de correo/notification según estado
                await SendRequestStatusNotificationAsync(request, statusTypeId);

                // 4. Si es aprobada, ejecutar acción especial
                if (statusTypeId == 8)  // Approved
                    await ExecuteActionAsync(request);

                return true;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ModificationRequest status");
                throw;
            }
        }

        /// <summary>
        /// Ejecuta acciones específicas cuando una solicitud es aprobada.
        /// </summary>
        /// <param name="request">La solicitud de modificación aprobada.</param>
        private async Task ExecuteActionAsync(ModificationRequest request)
        {
            try
            {
                switch (request.TypeRequest)
                {
                    case TypeRequest.Absence: 
                        await _doctorAbsenceHandler.HandleAsync(request);
                        break;

                    case TypeRequest.AccountUnlock:
                        await _userService.UpdateRestrictionPointsAsync(request.UserId, true);
                        break;

                    default:
                        // No hacer nada por ahora
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing action for approved ModificationRequest");
                throw;
            }
        }

        /// <summary>
        /// Envía notificaciones y correos electrónicos al usuario según el nuevo estado de la solicitud.
        /// </summary>
        /// <param name="request">La solicitud de modificación.</param>
        /// <param name="statusTypeId">Identificador del nuevo estado.</param>
        private async Task SendRequestStatusNotificationAsync(ModificationRequest request, int statusTypeId)
        {
            try
            {
                var user = await _userBusiness.GetById(request.UserId);
                if (user == null) return;

                (string subject, string body) email;
                (string title, string message, TypeNotification type, int statusId) notification;

                switch (statusTypeId)
                {
                    case 8: // Approved
                        email = EmailTemplateFactory.BuildApproved(user, request);
                        notification = NotificationFactory.BuildModificationApproved();
                        break;

                    case 9: // Rejected
                        email = EmailTemplateFactory.BuildRejected(user, request);
                        notification = NotificationFactory.BuildModificationRejected();
                        break;

                    default:
                        return; // ningún correo para otros estados
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
                _logger.LogError(ex, "Error sending request status notification");
                throw;
            }
        }
    }
}
