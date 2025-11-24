using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel.Notification;
using Business_Back.Interface.IBusinessModel.Services;
using Business_Back.Interface.Socket;
using Entity_Back.Dto.Notification;
using Microsoft.Extensions.Configuration;
using Utilities_Back.Message.Email;

namespace Business_Back.Services.Notification
{
    /// <summary>
    /// Servicio encargado de enviar mensajes por correo electrónico y notificaciones internas en tiempo real.
    /// </summary>
    public class MessageSenderService : IMessageSenderService
    {
        private readonly IConfiguration _configuration;
        private readonly INotificationBusiness _notificationBusiness;
        private readonly INotificationSender _notificationSender;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MessageSenderService"/>.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="notificationBusiness">Lógica de negocio para notificaciones.</param>
        /// <param name="notificationSender">Servicio para enviar notificaciones en tiempo real.</param>
        public MessageSenderService(
            IConfiguration configuration,
            INotificationBusiness notificationBusiness,
            INotificationSender notificationSender)
        {
            _configuration = configuration;
            _notificationBusiness = notificationBusiness;
            _notificationSender = notificationSender;
        }

        /// <summary>
        /// Envía un correo electrónico y una notificación interna al usuario especificado.
        /// </summary>
        /// <param name="payload">Datos necesarios para el envío del correo y la notificación.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task SendAsync(NotificationEmailPayload payload, CancellationToken ct)
        {
            try
            {
                // (ES): Enviar correo
                await CorreoMensaje.EnviarAsync(
                    _configuration,
                    payload.Email,
                    payload.Subject,
                    payload.Body
                );

                // (ES): Crear notificación interna
                var noti = new NotificationCreateDto
                {
                    Title = payload.NotificationTitle,
                    Message = payload.NotificationMessage,
                    UserId = payload.UserId,
                    TypeNotification = payload.TypeNotification,
                    StatustypesId = payload.StatusTypesId
                };

                var saved = await _notificationBusiness.Save(noti);

                // (ES): Enviar notificación en tiempo real
                await _notificationSender.SendToUser(payload.UserId, saved);
            }
            catch (Exception)
            {
                // Manejo de excepciones (puede ser extendido para logging, etc.)
                throw;
            }
        }
    }

}
