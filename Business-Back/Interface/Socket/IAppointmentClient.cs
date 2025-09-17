using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Websocket.Broadcast;

namespace Business_Back.Interface.Socket
{
    public interface IAppointmentClient
    {
        Task SlotLocked(SlotLockedEvent evt);
        Task SlotUnlocked(SlotUnlockedEvent evt);
        Task SlotBooked(SlotBookedEvent evt);
    }
}
