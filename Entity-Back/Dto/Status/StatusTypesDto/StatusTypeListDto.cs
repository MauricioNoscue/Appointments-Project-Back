using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;
using Entity_Back.Models;

namespace Entity_Back.Dto.Status.StatusTypesDto
{
    public class StatusTypeListDto : BaseModel
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public CategoryStatus CategoryStatus { get; set; }
    }

}
