using Business_Back.Interface.IBusinessModel.Security;
using Business_Back.Interface.IBusinessModel.Status;
using Entity_Back.Dto.Status.StatusTypesDto;
using Web_back.Controllers.ControllerModel;
using Web_back.Controllers.Implements.Security;

namespace Web_back.Controllers.Implements.Status
{
    public class StatusTypeController : ControllerGeneric<StatusTypeCreateDto, StatusTypeEditDto, StatusTypeListDto>
    {
        private readonly IStatusTypeBusiness _service;
        public StatusTypeController(IStatusTypeBusiness userBusiness, ILogger<StatusTypeController> logger)
      : base(userBusiness, logger)
        {
            _service = userBusiness;
        }
    }
}
