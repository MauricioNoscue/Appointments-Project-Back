using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;
using Entity_Back.Models.SecurityModels;
using Entity_Back.Models.Status;

namespace Entity_Back.Models.Request
{
    public class ModificationRequest : BaseModel
    {
        public string Reason { get; set; }
        public TypeRequest TypeRequest { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int StatustypesId { get; set; }
        public StatusTypes Statustypes { get; set; }
        public string  Observation { get; set;}

    }
}
