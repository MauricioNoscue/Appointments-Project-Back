using Business_Back.Interface.Socket;
using Entity_Back.Dto.Websocket.Requests;
using Entity_Back.Dto.Websocket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Web_back.Hub
{
    [Authorize]
    public sealed class AppointmentHub : Hub<IAppointmentClient>
    {
        private readonly IAppointmentOrchestrator _app;

        public AppointmentHub(IAppointmentOrchestrator app) => _app = app;

        public Task JoinDay(int scheduleHourId, DateTime date)
            => Groups.AddToGroupAsync(Context.ConnectionId, GroupName(scheduleHourId, date));

        public Task LeaveDay(int scheduleHourId, DateTime date)
            => Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName(scheduleHourId, date));

        public async Task<SlotLockResponse> LockSlot(SlotLockRequest req)
        {
            // Busca el claim directamente del User
            var userId = Context.User?.FindFirst("sub")?.Value
                          ?? Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new HubException("No user id in token");

            return await _app.TryLockAsync(req, userId, CancellationToken.None);
        }

        public async Task<SlotUnlockResponse> UnlockSlot(SlotUnlockRequest req)
        {
            var userId = Context.UserIdentifier;   
            if (string.IsNullOrEmpty(userId))
                throw new HubException("No user id in token");

            return await _app.TryUnlockAsync(req, userId, CancellationToken.None);
        }

        public async Task<object> ConfirmSlot(SlotKey slot)
        {
            var userIdStr = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userIdStr))
                throw new HubException("No user id in token");

            var userId = int.Parse(userIdStr);
            var (ok, id, reason) = await _app.ConfirmAsync(slot, userId, CancellationToken.None);
            return new { success = ok, citationId = id, reason };
        }

        private static string GroupName(int scheduleHourId, DateTime date)
            => $"schedule:{scheduleHourId}:{date:yyyyMMdd}";
    }
}
