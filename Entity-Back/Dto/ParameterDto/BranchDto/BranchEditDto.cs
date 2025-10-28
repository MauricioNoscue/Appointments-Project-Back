using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.BranchDto
{
    using System.ComponentModel.DataAnnotations;

    public class BranchEditDto
    {
        [Required(ErrorMessage = "El Id de la sede es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe proporcionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la sede es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
        [StringLength(10, ErrorMessage = "El teléfono no puede superar los 10 caracteres")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La institución es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una institución válida")]
        public int InstitutionId { get; set; }
    }

}
