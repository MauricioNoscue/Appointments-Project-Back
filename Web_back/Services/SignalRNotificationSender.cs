using Business_Back.Interface.Socket;
using Entity_Back.Dto.Notification;
using Microsoft.AspNetCore.SignalR;
using Web_back.Hub;

namespace Web_back.Services
{
    public sealed class SignalRNotificationSender : INotificationSender
    {
        private readonly IHubContext<NotificationHub, INotificationClient> _hub;

        public SignalRNotificationSender(
            IHubContext<NotificationHub, INotificationClient> hub)
        {
            _hub = hub;
        }

        public Task SendToUser(int userId, NotificationListDto dto)
        {
            string group = $"user:{userId}";
            Console.WriteLine($"🔥 SignalR conectado al signal rn  — userId = {userId}");
            Console.WriteLine("DTO ENVIADO POR SIGNALR:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(dto));

            return _hub.Clients.Group(group).ReceiveNotification(dto);
        }
    }
}
