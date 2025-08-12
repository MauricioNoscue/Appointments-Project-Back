using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.SecurityModels
{
    public class Permission : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RolFormPermission> RolFormPermission { get; set; } = new List<RolFormPermission>();

    }
}
