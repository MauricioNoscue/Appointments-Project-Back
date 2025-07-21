using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Entity_Back.Dto.SecurityDto.RolFormPermissionDto
{
    public class RolFormPermissionListDto : BaseModel
    {
        public string RolName { get; set; }
        public string FormName { get; set; }
        public string PermissionName { get; set; }

    }
}
