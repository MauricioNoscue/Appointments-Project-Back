using System.Security.Claims;
using Business_Back.Interface.Socket;
using Entity_Back.Models.SecurityModels;
using Microsoft.AspNetCore.SignalR;

namespace Web_back.Hub
{
    public class NotificationHub : Hub<INotificationClient>
    {

       public override Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirst("sub")?.Value?? Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(!string.IsNullOrEmpty(userId))
            {

                Groups.AddToGroupAsync(Context.ConnectionId, $"user:{userId}");
                Console.WriteLine($"🔥 SignalR conectado al notifica — userId = {userId}");
            }

            return base.OnConnectedAsync();

        }


    }
}
