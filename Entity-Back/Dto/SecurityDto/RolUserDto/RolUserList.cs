using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Entity_Back.Dto.SecurityDto.RolUserDto
{
    public class RolUserList : BaseModel
    {
        public int RolId { get; set; }
        public int UserId { get; set; }
        public string RolName { get; set; }
        public string Email { get; set; }
    }
}
