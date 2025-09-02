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
        public int CitationId { get; set; }
        public string Message { get; set; } = null!;
        public bool StateNotification { get; set; }

        public string? TypeCitationName { get; set; }

    }
}
