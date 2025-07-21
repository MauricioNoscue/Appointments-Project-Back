using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.Security;

namespace Entity_Back.Models.SecurityModels
{
    public class RolFormPermission :  BaseModel
    {
        public Rol Rol { get; set; }
        public Form Form { get; set; }
        public Permission Permission { get; set; }

        public int RolId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }


    }
}
