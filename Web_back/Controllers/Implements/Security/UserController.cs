using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.UserDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class UserController :ControllerGeneric<UserCreatedDto, UserEditDto, UserListDto>
    {
        public UserController( IBaseModelBusiness<UserCreatedDto, UserEditDto, UserListDto> service,ILogger<UserController> logger)
            : base(service,logger)
        {
            
        }
    }
}
