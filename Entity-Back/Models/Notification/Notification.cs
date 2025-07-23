using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.Notification
{
    public class Notification : BaseModel
    {
        public int CitationId { get; set; }
        public string Message { get; set; }
        public string StateNotification { get; set; }
        public string TypeNotification { get; set; }
        public Citation citation { get; set; }
    }
}
