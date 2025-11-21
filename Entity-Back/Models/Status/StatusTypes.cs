using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;
using Entity_Back.Models.Notification;
using Entity_Back.Models.Request;

namespace Entity_Back.Models.Status
{
    public class StatusTypes : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryStatus CategoryStatus { get; set; }
        public List<Notifications> Notifications { get; set; }
        public List<Citation> Citation { get; set; }
        public List<ModificationRequest> ModificationRequests { get; set; }

    }
}
