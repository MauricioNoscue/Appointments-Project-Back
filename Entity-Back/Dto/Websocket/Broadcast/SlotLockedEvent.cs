using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Websocket.Broadcast
{
    public record SlotLockedEvent(SlotKey Slot, string LockOwnerUserId, DateTime LockedUntil);
}
