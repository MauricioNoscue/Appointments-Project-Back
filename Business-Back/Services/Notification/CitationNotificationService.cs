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
    public class CitationNotificationService : ICitationNotificationService
    {
        private readonly IConfiguration _configuration;
        private readonly INotificationBusiness _notificationBusiness;
        private readonly INotificationSender _notificationSender;
        private readonly IMessageSenderService _sender;
        private readonly IUserData _userData;

        public CitationNotificationService(
            IConfiguration configuration,
            INotificationBusiness notificationBusiness,
            INotificationSender notificationSender,
            IMessageSenderService sender,
            IUserData userData
            )
        {
            _configuration = configuration;
            _notificationBusiness = notificationBusiness;
            _notificationSender = notificationSender;
            _sender = sender;
            _userData = userData;
        }

        public async Task SendCitationConfirmationAsync(Entity_Back.Citation citation, CancellationToken ct)
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

                case 10: // Reprogramada (tu lógica marca la original como 2 y la nueva como 1, PERO SI TIENES UN STATUS EXPLÍCITO, aquí va)
                    email = EmailTemplateFactory.BuildCitationRescheduled(user, citation);
                    notification = NotificationFactory.BuildCitationRescheduled();
                    break;

                default:
                    throw new InvalidOperationException($"No template configured for status {citation.StatustypesId}");
            }

            // (ES): Armar payload genérico
            var payload = new NotificationEmailPayload
            {
                Email = user.Email,
                Subject = email.subject,
                Body = email.body,
                UserId = user.Id,
                NotificationTitle = notification.title,
                NotificationMessage = notification.message,
                TypeNotification = notification.type,
                StatusTypesId = notification.statusId
            };

            // (ES): Enviar correo + notificación
            await _sender.SendAsync(payload, ct);
        }


    }

}
