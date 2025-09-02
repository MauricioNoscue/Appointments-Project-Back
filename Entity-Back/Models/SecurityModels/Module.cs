using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.SecurityModels
{
    public class Module : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Icon { get; set; } // <-- Nuevo campo

        public List<Form> Form { get; set; } = new List<Form>();

    }
}
