using Business_Back.Interface.Socket;
using Entity_Back.Dto.Websocket.Requests;
using Entity_Back.Dto.Websocket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using System.IdentityModel.Tokens.Jwt;

namespace Web_back.Hub
{

    [Authorize] // (ES): Usa auth para tener UserIdentifier
    public sealed class AppointmentHub : Hub<IAppointmentClient>
    {
        private readonly IAppointmentOrchestrator _app;

        public AppointmentHub(IAppointmentOrchestrator app) => _app = app;

        /// <summary>
        /// Joins the SignalR group for the given scheduleHour and date.
        /// </summary>
        /// <remarks>(ES): Suscribe la conexión al grupo de un día concreto.</remarks>
        public async Task JoinDay(int scheduleHourId, DateTime date)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupName(scheduleHourId, date));
        }

        /// <summary>
        /// Leaves the group for the given day/schedule.
        /// </summary>
        /// <remarks>(ES): Quita la conexión del grupo cuando se abandona la vista.</remarks>
        public async Task LeaveDay(int scheduleHourId, DateTime date)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName(scheduleHourId, date));
        }

        /// <summary>
        /// Requests a temporary lock (hold) for a time slot.
        /// </summary>
        /// <remarks>(ES): Usa el UserIdentifier del contexto para ownership del lock.</remarks>
        public async Task<SlotLockResponse> LockSlot(SlotLockRequest req, CancellationToken ct)
        {
            var userId = Context.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new HubException("No user id in token");

            return await _app.TryLockAsync(req, userId, ct);
        }

        /// <summary>
        /// Releases a previously acquired lock.
        /// </summary>
        /// <remarks>(ES): Solo el dueño puede liberar el lock.</remarks>
        public async Task<SlotUnlockResponse> UnlockSlot(SlotUnlockRequest req, CancellationToken ct)
        {
            var userId = Context.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new HubException("No user id in token");

            return await _app.TryUnlockAsync(req, userId, ct);
        }

        /// <summary>
        /// Confirms the booking for a locked slot.
        /// </summary>
        /// <remarks>(ES): Inserta la cita transaccionalmente y hace broadcast.</remarks>
        public async Task<object> ConfirmSlot(SlotKey slot, CancellationToken ct)
        {
            var userIdStr = Context.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdStr))
                throw new HubException("No user id in token");

            var userId = int.Parse(userIdStr);
            var (ok, id, reason) = await _app.ConfirmAsync(slot, userId, ct);
            return new { success = ok, citationId = id, reason };
        }

        private static string GroupName(int scheduleHourId, DateTime date)
            => $"schedule:{scheduleHourId}:{date:yyyyMMdd}";
    }
}
