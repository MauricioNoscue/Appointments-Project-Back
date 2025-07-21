using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.ModuleDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class ModuleController : ControllerGeneric<ModuleCreatedDto, ModuleEditDto, ModuleListDto>
    {
        public ModuleController(IBaseModelBusiness<ModuleCreatedDto, ModuleEditDto, ModuleListDto> service,
                                ILogger<ModuleController> logger)
            : base(service, logger)
        {
        }
    }

}
