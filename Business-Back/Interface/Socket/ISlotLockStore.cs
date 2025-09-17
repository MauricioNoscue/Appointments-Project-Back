using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Websocket;

namespace Business_Back.Interface.Socket
{
    public interface ISlotLockStore
    {
        /// <summary>
        /// Try to acquire a lock for the given slot. Returns whether it was acquired,
        /// the expiration time and the current owner (if any).
        /// </summary>
        /// <remarks>(ES): Crea un hold con TTL. Si ya existe y no está expirado, no adquiere.</remarks>
        Task<(bool acquired, DateTime? lockedUntil, string? owner)> TryAcquireAsync(
            SlotKey slot, string userId, TimeSpan ttl, CancellationToken ct);

        /// <summary>
        /// Try to release the lock if the caller is the current owner.
        /// </summary>
        /// <remarks>(ES): Solo el dueño puede liberar el lock.</remarks>
        Task<(bool released, string? owner)> TryReleaseAsync(
            SlotKey slot, string userId, CancellationToken ct);

        /// <summary>
        /// Check current ownership and expiration info.
        /// </summary>
        /// <remarks>(ES): Útil antes de confirmar la cita.</remarks>
        Task<(bool owned, DateTime? lockedUntil, string? owner)> CheckAsync(
            SlotKey slot, string userId, CancellationToken ct);
    }
}
