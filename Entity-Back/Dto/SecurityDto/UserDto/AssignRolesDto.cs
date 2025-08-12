using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.UserDto
{
    public class AssignRolesDto
    {
        public int UserId { get; set; }
        public List<int> RolIds { get; set; }
    }

}
