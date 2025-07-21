using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class RolUserController : ControllerGeneric<RolUserCreatedDto, RolUserEditDto, RolUserList>
    {
        public RolUserController(IBaseModelBusiness<RolUserCreatedDto, RolUserEditDto, RolUserList> service, ILogger<RolUserController> logger):
            base(service, logger) 
        {
            
        }
    }
}
