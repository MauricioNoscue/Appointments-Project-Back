using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.RolFormPermissionDto
{
    public class RolFormPermissionCreatedDto
    {
        [Required(ErrorMessage = "El rol es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un rol válido")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El formulario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un formulario válido")]
        public int FormId { get; set; }

        [Required(ErrorMessage = "El permiso es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un permiso válido")]
        public int PermissionId { get; set; }
    }


}
