using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class EpsController : ControllerGeneric<EpsCreatedDto, EpsEditDto, EpsListDto>
    {
        public EpsController(IBaseModelBusiness<EpsCreatedDto, EpsEditDto, EpsListDto> service,
                            ILogger<EpsController> logger)
            : base(service, logger)
        {
        }
    }
}