using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.FormDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class FormController : ControllerGeneric<FormCreatedDto, FormEditDto, FormListDto>
    {
        public FormController(IBaseModelBusiness<FormCreatedDto, FormEditDto, FormListDto> service,
                              ILogger<FormController> logger)
            : base(service, logger)
        {
        }
    }

}
