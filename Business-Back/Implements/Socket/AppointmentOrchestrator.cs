using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.Socket;
using Data_Back;
using Entity_Back.Context;
using Entity_Back.Dto.Websocket.Broadcast;
using Entity_Back.Dto.Websocket.Requests;
using Entity_Back.Dto.Websocket;
using Entity_Back;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business_Back.Implements.Socket
{
    public sealed class AppointmentOrchestrator : IAppointmentOrchestrator
    {
        private readonly ISlotLockStore _locks;                 // (ES): Maneja holds en Redis
        private readonly ICitationsData _citaData;              // (ES): Acceso a datos de citas (si lo necesitas)
        private readonly ApplicationDbContext _db;              // (ES): Para transacción e inserción
        private readonly IAppointmentNotifier _notifier;        // (ES): Notificación desacoplada

        private static readonly TimeSpan HoldTtl = TimeSpan.FromSeconds(120); // (ES): TTL configurable

        public AppointmentOrchestrator(
            ISlotLockStore locks,
            ICitationsData citaData,
            ApplicationDbContext db,
            IAppointmentNotifier notifier)
        {
            _locks = locks ?? throw new ArgumentNullException(nameof(locks));
            _citaData = citaData ?? throw new ArgumentNullException(nameof(citaData));
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        }

        /// <inheritdoc />
        public async Task<SlotLockResponse> TryLockAsync(SlotLockRequest req, string userId, CancellationToken ct)
        {
            SlotKey slot = new SlotKey(req.ScheduleHourId, req.Date.Date, req.TimeBlock);
            (bool acquired, DateTime? until, string? owner) = await _locks.TryAcquireAsync(slot, userId, HoldTtl, ct);

            if (acquired)
            {
                // (ES): Broadcast a todos los clientes del grupo (día + schedule) vía notifier
                SlotLockedEvent evt = new SlotLockedEvent(slot, userId, until!.Value);
                string group = GroupName(slot);
                await _notifier.NotifySlotLocked(evt, group);

                return new SlotLockResponse(true, null, slot, userId, until);
            }

            return new SlotLockResponse(false, "Slot already locked", slot, owner, until);
        }

        /// <inheritdoc />
        public async Task<SlotUnlockResponse> TryUnlockAsync(SlotUnlockRequest req, string userId, CancellationToken ct)
        {
            SlotKey slot = new SlotKey(req.ScheduleHourId, req.Date.Date, req.TimeBlock);
            (bool released, string? _) = await _locks.TryReleaseAsync(slot, userId, ct);

            if (released)
            {
                SlotUnlockedEvent evt = new SlotUnlockedEvent(slot);
                string group = GroupName(slot);
                await _notifier.NotifySlotUnlocked(evt, group);
            }

            return new SlotUnlockResponse(released, slot);
        }

        /// <inheritdoc />
        public async Task<(bool success, int? citationId, string? reason)> ConfirmAsync(SlotKey slot, int userId, CancellationToken ct)
        {
            // (ES): Garantiza que el lock aún pertenece al usuario
            (bool owned, DateTime? _, string? owner) = await _locks.CheckAsync(slot, userId.ToString(), ct);
            if (!owned)
            {
                return (false, null, $"Slot not locked by you (owner: {owner})");
            }

            // (ES): Transacción para insertar y asegurar atomicidad
            await using (IDbContextTransaction tx = await _db.Database.BeginTransactionAsync(ct))
            {
                try
                {
                    Citation entity = new Citation
                    {
                        UserId = userId,
                        AppointmentDate = slot.Date,
                        TimeBlock = slot.TimeBlock,
                        State = "Booked",
                        Note = string.Empty,
                        ScheduleHourId = slot.ScheduleHourId,
                        IsDeleted = false,
                        RegistrationDate = DateTime.UtcNow
                    };

                    _db.Set<Citation>().Add(entity);
                    await _db.SaveChangesAsync(ct);

                    // (ES): Opcional: liberar hold (ya está BOOKED)
                    await _locks.TryReleaseAsync(slot, userId.ToString(), ct);

                    await tx.CommitAsync(ct);

                    // (ES): Notificar a todos que este slot quedó booked
                    SlotBookedEvent evt = new SlotBookedEvent(slot, entity.Id);
                    string group = GroupName(slot);
                    await _notifier.NotifySlotBooked(evt, group);

                    return (true, entity.Id, null);
                }
                catch (DbUpdateException)
                {
                    await tx.RollbackAsync(ct);
                    return (false, null, "Slot already booked");
                }
            }
        }

        // (ES): Convención de grupo (ScheduleHour + fecha). Los clientes se suscriben por vista/día.
        private static string GroupName(SlotKey slot)
        {
            return $"schedule:{slot.ScheduleHourId}:{slot.Date:yyyyMMdd}";
        }
    }
}
