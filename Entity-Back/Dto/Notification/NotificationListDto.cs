using Entity_Back.Enum;
using Entity_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Notification
{
    public class NotificationListDto: BaseModel
    {
        public string Title { get; set; }
        public int? CitationId { get; set; }
        public string Message { get; set; }
        public StatusNotification StateNotification { get; set; }
        public TypeNotification TypeNotification { get; set; }
        public Citation citation { get; set; }
        public string? RedirectUrl { get; set; }
        public int UserId { get; set; }

    }
}



