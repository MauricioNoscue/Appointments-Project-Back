using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.RolUserDto
{
    public class UserRoleDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El rol es obligatorio")]
        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un rol válido")]
        public int RolId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El usuario es obligatorio")]
        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un usuario válido")]
        public int UserId { get; set; }
    }

}
