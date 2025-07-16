using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.Security
{
    public class Rol: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
