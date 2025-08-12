using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models.Security
{
    public class Rol: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RolUser> RolUser { get; set; } = new List<RolUser>();
        public List<RolFormPermission> RolFormPermission { get; set; } = new List<RolFormPermission>();


    }
}
