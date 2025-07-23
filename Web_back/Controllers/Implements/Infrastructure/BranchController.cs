using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.InfrastructureDto.BranchDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Infrastructure
{

    public class BranchController : ControllerGeneric<BranchCreatedDto, BranchEditDto, BranchListDto>
    {
        public BranchController(IBaseModelBusiness<BranchCreatedDto, BranchEditDto, BranchListDto> service,
                              ILogger<BranchController> logger)
            : base(service, logger)
        {
        }
    }

}
