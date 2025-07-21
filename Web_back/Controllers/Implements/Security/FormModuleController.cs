using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.FormModuleDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class FormModuleController : ControllerGeneric<FormModuleCreatedDto, FormModuleEditDto, FormModuleListDto>
    {
        public FormModuleController(IBaseModelBusiness<FormModuleCreatedDto, FormModuleEditDto, FormModuleListDto> service,
                                    ILogger<FormModuleController> logger)
            : base(service, logger)
        {
        }
    }

}
