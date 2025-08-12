using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Dto.SecurityDto.UserDto;

namespace Business_Back.Interface.IBusinessModel.Security
{
    public interface IRolUserBusiness : IBaseModelBusiness<RolUserCreatedDto,RolUserEditDto,RolUserList>
    {
        public Task<IEnumerable<object>> GetRolesAndPermissionsByUserIdAsync(int userId);
        public  Task AssignRolesAsync(AssignRolesDto dto);
        public  Task UpdateUserRolesAsync(UpdateUserRolesDto dto);
    }
}
