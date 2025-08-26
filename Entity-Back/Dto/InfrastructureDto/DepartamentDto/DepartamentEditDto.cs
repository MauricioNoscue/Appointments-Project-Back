using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.DepartamentDto
{
    using System.ComponentModel.DataAnnotations;

    public class DepartamentEditDto
    {
        [Required(ErrorMessage = "El Id del departamento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe proporcionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre del departamento debe tener entre 2 y 50 caracteres")]
        public string Name { get; set; }
    }

}
