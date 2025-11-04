using Business_Back.Interface.Socket;
using Entity_Back.Dto.Websocket.Requests;
using Entity_Back.Dto.Websocket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Web_back.Hub
{
    /// <summary>
    /// Hub de SignalR para gestionar la reserva de citas.
    /// Permite a los clientes unirse a grupos por día y hora, bloquear/desbloquear slots y confirmar reservas.
    /// </summary>
    [Authorize]
    public sealed class AppointmentHub : Hub<IAppointmentClient>
    {
        /// <summary>
        /// Orquestador de citas inyectado para manejar la lógica de negocio.
        /// </summary>
        private readonly IAppointmentOrchestrator _app;

        /// <summary>
        /// Constructor que recibe el orquestador de citas.
        /// </summary>
        /// <param name="app">Instancia de IAppointmentOrchestrator.</param>
        public AppointmentHub(IAppointmentOrchestrator app) => _app = app;

        /// <summary>
        /// Une al cliente al grupo correspondiente al día y hora de la agenda.
        /// </summary>
        /// <param name="scheduleHourId">ID de la hora de la agenda.</param>
        /// <param name="date">Fecha de la cita.</param>
        public Task JoinDay(int scheduleHourId, DateTime date)
            => Groups.AddToGroupAsync(Context.ConnectionId, GroupName(scheduleHourId, date));

        /// <summary>
        /// Elimina al cliente del grupo correspondiente al día y hora de la agenda.
        /// </summary>
        /// <param name="scheduleHourId">ID de la hora de la agenda.</param>
        /// <param name="date">Fecha de la cita.</param>
        public Task LeaveDay(int scheduleHourId, DateTime date)
            => Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName(scheduleHourId, date));

        /// <summary>
        /// Solicita el bloqueo de un slot para el usuario actual.
        /// </summary>
        /// <param name="req">Datos de la solicitud de bloqueo.</param>
        /// <returns>Respuesta con el resultado del bloqueo.</returns>
        public async Task<SlotLockResponse> LockSlot(SlotLockRequest req)
        {
            // Busca el claim directamente del User
            var userId = Context.User?.FindFirst("sub")?.Value
                          ?? Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new HubException("No user id in token");

            return await _app.TryLockAsync(req, userId, CancellationToken.None);
        }

        /// <summary>
        /// Solicita desbloquear un slot previamente bloqueado por el usuario actual.
        /// </summary>
        /// <param name="req">Datos de la solicitud de desbloqueo.</param>
        /// <returns>Respuesta con el resultado del desbloqueo.</returns>
        public async Task<SlotUnlockResponse> UnlockSlot(SlotUnlockRequest req)
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId))
                throw new HubException("No user id in token");

            return await _app.TryUnlockAsync(req, userId, CancellationToken.None);
        }

        /// <summary>
        /// Confirma la reserva de un slot previamente bloqueado.
        /// </summary>
        /// <param name="slot">Clave del slot a confirmar.</param>
        /// <returns>Objeto con el resultado de la confirmación, id de la cita y motivo si falla.</returns>
        public async Task<object> ConfirmSlot(SlotKey slot)
        {
            var userIdStr = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userIdStr))
                throw new HubException("No user id in token");

            var userId = int.Parse(userIdStr);
            var (ok, id, reason) = await _app.ConfirmAsync(slot, userId, CancellationToken.None);
            return new { success = ok, citationId = id, reason };
        }

        /// <summary>
        /// Genera el nombre del grupo para SignalR basado en el id de la hora y la fecha.
        /// </summary>
        /// <param name="scheduleHourId">ID de la hora de la agenda.</param>
        /// <param name="date">Fecha de la cita.</param>
        /// <returns>Nombre del grupo.</returns>
        private static string GroupName(int scheduleHourId, DateTime date)
            => $"schedule:{scheduleHourId}:{date:yyyyMMdd}";
    }
}
