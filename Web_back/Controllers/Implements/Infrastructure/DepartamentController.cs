using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.InfrastructureDto.Departament;
using Entity_Back.Dto.InfrastructureDto.DepartamentDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Infrastructure
{

    public class DepartamentController : ControllerGeneric<DepartamentCreatedDto, DepartamentEditDto, DepartamentListDto>
    {
        public DepartamentController(IBaseModelBusiness<DepartamentCreatedDto, DepartamentEditDto, DepartamentListDto> service,
                              ILogger<DepartamentController> logger)
            : base(service, logger)
        {
        }
    }
}
