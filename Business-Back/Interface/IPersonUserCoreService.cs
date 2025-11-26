using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.UserDto;

namespace Business_Back.Interface
{
    public interface IPersonUserCoreService
    {
        Task<UserListDto> CreatePersonAndUserAsync(PersonUserCreateDto dto);
    }
}
