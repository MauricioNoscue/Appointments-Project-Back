using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class PermissionController : ControllerGeneric<PermissionCreatedDto, PermissionEditDto, PermissionListDto>
    {
        public PermissionController(IBaseModelBusiness<PermissionCreatedDto, PermissionEditDto, PermissionListDto> service,
                                    ILogger<PermissionController> logger)
            : base(service, logger)
        {
        }
    }

}
