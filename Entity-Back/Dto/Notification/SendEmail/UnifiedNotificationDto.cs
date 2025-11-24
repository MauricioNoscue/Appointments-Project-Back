using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Entity_Back.Dto.Notification.SendEmail
{
    public class UnifiedNotificationDto
    {
        public int UserId { get; set; }        // receptor
        public string Email { get; set; } = "";

        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";

        public string NotificationTitle { get; set; } = "";
        public string NotificationMessage { get; set; } = "";
        public TypeNotification TypeNotification { get; set; }
        public int StatusTypesId { get; set; }
    }

}
