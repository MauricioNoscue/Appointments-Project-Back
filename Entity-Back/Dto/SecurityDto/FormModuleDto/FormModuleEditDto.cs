using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.FormModuleDto
{
    public class FormModuleEditDto
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El formulario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un formulario válido")]
        public int FormId { get; set; }

        [Required(ErrorMessage = "El módulo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un módulo válido")]
        public int ModuleId { get; set; }
    }

}
