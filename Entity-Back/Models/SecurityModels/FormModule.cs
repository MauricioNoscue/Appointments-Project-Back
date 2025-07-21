using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.SecurityModels
{
    public class FormModule : BaseModel
    {
        public int ModuleId { get; set; }
        public int FormId { get; set; }
        public Module Module { get; set; }
        public Form Form { get; set; }
    }
}
