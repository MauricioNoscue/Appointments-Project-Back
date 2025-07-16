using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.RolDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class RolController : ControllerGeneric<RolCreatedDto,RolEditDto,RolListDto>
    {
        public RolController( IBaseModelBusiness<RolCreatedDto, RolEditDto, RolListDto> service,ILogger<RolController> logger): 
            base( service,logger)
        {
            
        }
    }
}
