using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.CityDto
{
    using System.ComponentModel.DataAnnotations;

    public class CityCreatedDto
    {
        [Required(ErrorMessage = "El departamento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un departamento válido")]
        public int DepartamentId { get; set; }

        [Required(ErrorMessage = "El nombre de la ciudad es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la ciudad debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; }
    }

}
