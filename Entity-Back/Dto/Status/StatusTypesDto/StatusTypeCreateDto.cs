using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Entity_Back.Dto.Status.StatusTypesDto
{
    public class StatusTypeCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public CategoryStatus CategoryStatus { get; set; }
    }

}
