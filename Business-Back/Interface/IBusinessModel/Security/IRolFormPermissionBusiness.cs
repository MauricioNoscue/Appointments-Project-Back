using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;

namespace Business_Back.Interface.IBusinessModel.Security
{
    public interface IRolFormPermissionBusiness : IBaseModelBusiness<RolFormPermissionCreatedDto, RolFormPermissionEditDto, RolFormPermissionListDto>
    {
        public  Task AssignPermissionsAsync(AssignPermissionsDto dto);
        public Task UpdateRolFormPermissionsAsync(UpdateRolFormPermissionsDto dto);
    }

}
