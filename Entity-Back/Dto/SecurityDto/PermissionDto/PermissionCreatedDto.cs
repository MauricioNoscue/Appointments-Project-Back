using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.PermissionDto
{
    public class PermissionCreatedDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 200 caracteres")]
        public string? Description { get; set; }   // opcional, pero validada si llega
    }

}
