using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Websocket.Broadcast;

namespace Business_Back.Interface.Socket
{
    public interface IAppointmentNotifier
    {
        /// <summary>Broadcast locked event to a specific group.</summary>
        /// <param name="evt">(ES): Evento de slot bloqueado.</param>
        /// <param name="groupName">(ES): Nombre del grupo SignalR.</param>
        Task NotifySlotLocked(SlotLockedEvent evt, string groupName);

        /// <summary>Broadcast unlocked event to a specific group.</summary>
        /// <param name="evt">(ES): Evento de slot liberado.</param>
        /// <param name="groupName">(ES): Nombre del grupo SignalR.</param>
        Task NotifySlotUnlocked(SlotUnlockedEvent evt, string groupName);

        /// <summary>Broadcast booked event to a specific group.</summary>
        /// <param name="evt">(ES): Evento de slot reservado (booked).</param>
        /// <param name="groupName">(ES): Nombre del grupo SignalR.</param>
        Task NotifySlotBooked(SlotBookedEvent evt, string groupName);
    }
}
