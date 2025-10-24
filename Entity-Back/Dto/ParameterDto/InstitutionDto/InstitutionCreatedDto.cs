using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.InstitutionDto
{
    public class InstitutionCreatedDto
    {
        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una ciudad válida")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "El nombre de la institución es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El NIT es obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El NIT debe tener entre 5 y 20 caracteres")]
        public string Nit { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres")]
        public string Email { get; set; }
    }
}
