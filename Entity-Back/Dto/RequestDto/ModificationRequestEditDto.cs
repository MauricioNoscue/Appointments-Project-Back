using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Entity_Back.Dto.RequestDto
{
    public class ModificationRequestEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public TypeRequest TypeRequest { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int StatustypesId { get; set; }

        public string? Observation { get; set; }
    }

}
