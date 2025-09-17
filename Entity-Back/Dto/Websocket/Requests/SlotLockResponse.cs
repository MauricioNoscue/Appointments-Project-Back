using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Websocket.Requests
{
    public record SlotLockResponse(bool Locked, string? Reason, SlotKey Slot, string? LockOwnerUserId, DateTime? LockedUntil);
}
