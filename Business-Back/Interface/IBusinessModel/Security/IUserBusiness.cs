using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Models.SecurityModels;

namespace Business_Back.Interface.IBusinessModel.Security
{
    public interface IUserBusiness : IBaseModelBusiness<UserCreatedDto,UserEditDto,UserListDto>
    {
        public Task<UserDetailDto> GetUserDetailAsync(int id);

        Task<string?> RequestPasswordResetAsync(string email);

        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

        Task<bool> UpdateRestrictionPointsAsync(int userId, bool restore = false);

        Task<int?> GetByUserc(int userId);

        Task<bool> ToggleReschedulingAsync(int userId);
    }
}
