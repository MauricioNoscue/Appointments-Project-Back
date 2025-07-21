using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class RolFormPermissionController : ControllerGeneric<RolFormPermissionCreatedDto, RolFormPermissionEditDto, RolFormPermissionListDto>
    {
        public RolFormPermissionController(IBaseModelBusiness<RolFormPermissionCreatedDto, RolFormPermissionEditDto, RolFormPermissionListDto> service,
                                           ILogger<RolFormPermissionController> logger)
            : base(service, logger)
        {
        }
    }

}
