using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.Security;

namespace Entity_Back.Models.SecurityModels
{
    public class RolUser : BaseModel
    {
        public int RolId { get; set; }
        public int UserId { get; set; }
        public Rol Rol { get; set; }
        public User User { get; set; }
    }
}
