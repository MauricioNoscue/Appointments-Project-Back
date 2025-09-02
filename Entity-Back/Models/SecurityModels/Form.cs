using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.SecurityModels
{
    public class Form : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }


        public string? Icon { get; set; } // <-- Nuevo campo
        public int ModuleId { get; set; }
        public Module Module { get; set; }

    }
}
