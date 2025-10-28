using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.Departament
{
    public class DepartamentCreatedDto
    {

        [Required(ErrorMessage = "El nombre del de partamento es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del de partamento debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }
    }
}
