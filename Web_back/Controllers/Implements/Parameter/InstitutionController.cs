using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.InfrastructureDto.InstitutionDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Infrastructure
{

    public class InstitutionController : ControllerGeneric<InstitutionCreatedDto, InstitutionEditDto, InstitutionListDto>
    {
        public InstitutionController(IBaseModelBusiness<InstitutionCreatedDto, InstitutionEditDto, InstitutionListDto> service,
                              ILogger<InstitutionController> logger)
            : base(service, logger)
        {
        }
    }
}
