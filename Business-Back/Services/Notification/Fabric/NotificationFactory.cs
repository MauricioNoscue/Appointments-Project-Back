using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Business_Back.Services.Notification.Fabric
{
    public static class NotificationFactory
    {
        public static (string title, string message, TypeNotification type, int statusId)
            BuildCitationCreated()
            => ("Cita programada", "Tu cita fue creada correctamente.", TypeNotification.Info, 1);

        public static (string title, string message, TypeNotification type, int statusId)
            BuildCitationRescheduled()
            => ("Cita reprogramada", "Tu cita fue reprogramada.", TypeNotification.Info, 5);

        public static (string title, string message, TypeNotification type, int statusId)
            BuildCitationCanceled()
            => ("Cita cancelada", "Tu cita fue cancelada.", TypeNotification.Warning, 2);
    }

}
