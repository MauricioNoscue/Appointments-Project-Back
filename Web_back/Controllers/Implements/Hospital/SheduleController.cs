using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Medical
{
    public class SheduleController : ControllerGeneric<SheduleCreateDto, SheduleEditDto, SheduleListDto>
    {
        public SheduleController(
            IBaseModelBusiness<SheduleCreateDto, SheduleEditDto, SheduleListDto> service,
            ILogger<SheduleController> logger)
            : base(service, logger)
        {
        }
    }
}
