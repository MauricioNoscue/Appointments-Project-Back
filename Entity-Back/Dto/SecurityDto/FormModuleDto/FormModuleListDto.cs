using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Entity_Back.Dto.SecurityDto.FormModuleDto
{
    public class FormModuleListDto : BaseModel
    {
        public string FormName { get; set; }
        public string ModuleName { get; set; }

    }
}
