using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.CityDto
{
    using System.ComponentModel.DataAnnotations;

    public class CityEditDto
    {
        [Required(ErrorMessage = "El Id de la ciudad es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe proporcionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un departamento válido")]
        public int DepartamentId { get; set; }

        [Required(ErrorMessage = "El nombre de la ciudad es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre de la ciudad debe tener entre 2 y 50 caracteres")]
        public string Name { get; set; }
    }

}
