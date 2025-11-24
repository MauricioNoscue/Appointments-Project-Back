using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel.Notification;
using Business_Back.Interface.IBusinessModel.Services;
using Business_Back.Interface.Socket;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Dto.Notification;
using Entity_Back.Enum;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Utilities_Back.Helper;
using Utilities_Back.Message.Email;
using Business_Back.Services.Notification.Fabric;
using Data_Back.Interface.IDataModels.Security;

namespace Business_Back.Services.Notification
{
    /// <summary>
    /// Servicio encargado de gestionar el envío de notificaciones y correos electrónicos relacionados con citas.
    /// Utiliza un orquestador para unificar el envío de notificaciones internas y correos electrónicos según el estado de la cita.
    /// </summary>
    public class CitationNotificationService : ICitationNotificationService
    {
        private readonly IConfiguration _configuration;
        private readonly INotificationBusiness _notificationBusiness;
        private readonly INotificationSender _notificationSender;
        private readonly IMessageSenderService _sender;
        private readonly IUserData _userData;
        private readonly INotificationOrchestrator _emailOrchestator;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CitationNotificationService"/> con las dependencias requeridas.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="notificationBusiness">Lógica de negocio para notificaciones.</param>
        /// <param name="notificationSender">Servicio para enviar notificaciones internas.</param>
        /// <param name="sender">Servicio para enviar mensajes/correos electrónicos.</param>
        /// <param name="userData">Acceso a datos de usuario.</param>
        /// <param name="emailOrchestator">Orquestador de notificaciones unificadas.</param>
        public CitationNotificationService(
            IConfiguration configuration,
            INotificationBusiness notificationBusiness,
            INotificationSender notificationSender,
            IMessageSenderService sender,
            IUserData userData,
            INotificationOrchestrator emailOrchestator
            )
        {
            _configuration = configuration;
            _notificationBusiness = notificationBusiness;
            _notificationSender = notificationSender;
            _sender = sender;
            _userData = userData;
            _emailOrchestator = emailOrchestator;
        }

        /// <summary>
        /// Envía una confirmación de cita al usuario correspondiente, seleccionando la plantilla de correo y notificación interna
        /// según el estado de la cita (programada, cancelada o reprogramada).
        /// Utiliza el orquestador para unificar el envío.
        /// </summary>
        /// <param name="citation">Entidad de la cita a notificar.</param>
        /// <param name="ct">Token de cancelación para la operación asíncrona.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si no existe una plantilla configurada para el estado de la cita.</exception>
        public async Task SendCitationConfirmationAsync(Entity_Back.Citation citation, CancellationToken ct)
        {
            try
            {
                var user = await _userData.GetById(citation.UserId);

                // (ES): Evaluar qué template aplicar según el estado
                (string subject, string body) email;
                (string title, string message, TypeNotification type, int statusId) notification;

                switch (citation.StatustypesId)
                {
                    case 1: // Programada
                        email = EmailTemplateFactory.BuildCitationCreated(user, citation);
                        notification = NotificationFactory.BuildCitationCreated();
                        break;

                    case 2: // Cancelada
                        email = EmailTemplateFactory.BuildCitationCanceled(user, citation);
                        notification = NotificationFactory.BuildCitationCanceled();
                        break;

                    case 10: // Reprogramada
                        email = EmailTemplateFactory.BuildCitationRescheduled(user, citation);
                        notification = NotificationFactory.BuildCitationRescheduled();
                        break;

                    default:
                        throw new InvalidOperationException($"No template configured for status {citation.StatustypesId}");
                }

                // 2️⃣ Enviar usando el ORCHESTRATOR (reutilizable para cualquier caso)
                await _emailOrchestator.SendAsync(new UnifiedNotificationDto
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Subject = email.subject,
                    Body = email.body,
                    NotificationTitle = notification.title,
                    NotificationMessage = notification.message,
                    TypeNotification = notification.type,
                    StatusTypesId = notification.statusId
                }, ct);
            }
            catch (Exception)
            {
                // Manejo de excepciones: se puede agregar logging aquí si es necesario.
                throw;
            }
        }
    }

}
