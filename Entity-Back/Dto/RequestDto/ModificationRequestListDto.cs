using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;
using Entity_Back.Models;

namespace Entity_Back.Dto.RequestDto
{
    public class ModificationRequestListDto : BaseModel
    {
        public string Reason { get; set; }

        public TypeRequest TypeRequest { get; set; }

        public int UserId { get; set; }

        public string StatusTypeName { get; set; }

        public int StatusTypesId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Observation { get; set; }
    }

}
