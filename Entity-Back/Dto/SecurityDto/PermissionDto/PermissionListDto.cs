using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Entity_Back.Dto.SecurityDto.PermissionDto
{
    public class PermissionListDto : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
