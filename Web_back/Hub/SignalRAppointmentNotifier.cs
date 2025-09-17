using Business_Back.Interface.Socket;
using Entity_Back.Dto.Websocket.Broadcast;
using Microsoft.AspNetCore.SignalR;

namespace Web_back.Hub
{
    public sealed class SignalRAppointmentNotifier : IAppointmentNotifier
    {
        private readonly IHubContext<AppointmentHub, IAppointmentClient> _hub;

        public SignalRAppointmentNotifier(IHubContext<AppointmentHub, IAppointmentClient> hub)
        {
            _hub = hub;
        }

        public Task NotifySlotLocked(SlotLockedEvent evt, string groupName)
        {
            // (ES): Emite a todos los clientes del grupo que el slot fue bloqueado.
            return _hub.Clients.Group(groupName).SlotLocked(evt);
        }

        public Task NotifySlotUnlocked(SlotUnlockedEvent evt, string groupName)
        {
            // (ES): Emite a todos los clientes del grupo que el slot fue liberado.
            return _hub.Clients.Group(groupName).SlotUnlocked(evt);
        }

        public Task NotifySlotBooked(SlotBookedEvent evt, string groupName)
        {
            // (ES): Emite a todos los clientes del grupo que el slot fue reservado.
            return _hub.Clients.Group(groupName).SlotBooked(evt);
        }
    }
}
