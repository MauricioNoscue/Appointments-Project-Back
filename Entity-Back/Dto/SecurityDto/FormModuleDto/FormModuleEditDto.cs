using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.FormModuleDto
{
    public class FormModuleEditDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int ModuleId { get; set; }
    }
}
