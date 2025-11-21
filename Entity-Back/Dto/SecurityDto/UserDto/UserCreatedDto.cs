using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.PersonDto;

namespace Entity_Back.Dto.SecurityDto.UserDto
{

    public class UserCreatedDto
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El correo debe tener entre 5 y 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]

        [StringLength(50, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 50 caracteres")]
        public string Password { get; set; }

        public bool Active { get; set; }

        [Required(ErrorMessage = "La persona asociada es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una persona válida")]
        public int PersonId { get; set; }
        public bool Rescheduling { get; set; } = false;

    }
}
