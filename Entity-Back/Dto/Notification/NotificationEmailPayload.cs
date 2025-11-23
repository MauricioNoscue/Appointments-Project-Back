using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Entity_Back.Dto.Notification
{
    public class NotificationEmailPayload
    {
        // (ES): Parámetros para correo
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        // (ES): Parámetros para notificación interna
        public int UserId { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationMessage { get; set; }
        public TypeNotification TypeNotification { get; set; }
        public int StatusTypesId { get; set; }
    }

}
