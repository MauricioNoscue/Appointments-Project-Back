using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.RolFormPermissionDto
{
    public class UpdateRolFormPermissionsDto
    {
        public int RolId { get; set; }
        public List<PermissionAssignmentDto> Permissions { get; set; } // Deseados
    }

}
