using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.Socket;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Dto.Notification;
using Business_Back.Interface.IBusinessModel.Services;

namespace Business_Back.Services.Notification
{
    /// <summary>
    /// Orquestador de notificaciones encargado de enviar notificaciones unificadas a través del servicio de mensajería.
    /// </summary>
    public class NotificationOrchestrator : INotificationOrchestrator
    {
        private readonly IMessageSenderService _sender;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotificationOrchestrator"/>.
        /// </summary>
        /// <param name="sender">Servicio para el envío de mensajes.</param>
        public NotificationOrchestrator(IMessageSenderService sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Envía una notificación unificada de manera asíncrona.
        /// </summary>
        /// <param name="dto">DTO con la información de la notificación.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        public async Task SendAsync(UnifiedNotificationDto dto, CancellationToken ct)
        {
            try
            {
                var payload = new NotificationEmailPayload
                {
                    Email = dto.Email,
                    Subject = dto.Subject,
                    Body = dto.Body,
                    UserId = dto.UserId,
                    NotificationTitle = dto.NotificationTitle,
                    NotificationMessage = dto.NotificationMessage,
                    TypeNotification = dto.TypeNotification,
                    StatusTypesId = dto.StatusTypesId
                };

                await _sender.SendAsync(payload, ct);
            }
            catch (Exception)
            {
                // Manejo de excepción (puede ser log o relanzar según la implementación)
                throw;
            }
        }
    }

}
