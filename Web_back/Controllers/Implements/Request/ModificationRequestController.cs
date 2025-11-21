using Business_Back.Interface.IBusinessModel.Request;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.RequestDto;
using Web_back.Controllers.ControllerModel;
using Web_back.Controllers.Implements.Security;

namespace Web_back.Controllers.Implements.Request
{
    public class ModificationRequestController : ControllerGeneric<ModificationRequestCreateDto, ModificationRequestEditDto, ModificationRequestListDto>
    {
        private readonly IModificationRequestBusiness _service;
        public ModificationRequestController(IModificationRequestBusiness userBusiness, ILogger<ModificationRequestController> logger)
     : base(userBusiness, logger)
        {
            _service = userBusiness;
        }
    }
}
