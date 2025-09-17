using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Websocket.Requests;
using Entity_Back.Dto.Websocket;

namespace Business_Back.Interface.Socket
{
    public interface IAppointmentOrchestrator
    {
        /// <summary>
        /// Tries to lock a slot for the current user.
        /// </summary>
        /// <remarks>(ES): Crea un hold temporal en Redis y notifica a los clientes del grupo.</remarks>
        Task<SlotLockResponse> TryLockAsync(SlotLockRequest req, string userId, CancellationToken ct);

        /// <summary>
        /// Tries to unlock a slot owned by the current user.
        /// </summary>
        /// <remarks>(ES): Libera el hold y notifica a los clientes.</remarks>
        Task<SlotUnlockResponse> TryUnlockAsync(SlotUnlockRequest req, string userId, CancellationToken ct);

        /// <summary>
        /// Confirms the booking for a locked slot.
        /// </summary>
        /// <remarks>(ES): Valida ownership, inserta la Citation transaccionalmente y emite evento.</remarks>
        Task<(bool success, int? citationId, string? reason)> ConfirmAsync(SlotKey slot, int userId, CancellationToken ct);
    }
}
