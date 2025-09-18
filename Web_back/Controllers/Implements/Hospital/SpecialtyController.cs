using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class SpecialtyController : ControllerGeneric<SpecialtyCreatedDto, SpecialtyEditDto, SpecialtyListDto>
    {
        public SpecialtyController(IBaseModelBusiness<SpecialtyCreatedDto, SpecialtyEditDto, SpecialtyListDto> service,
                            ILogger<SpecialtyController> logger)
            : base(service, logger)
        {
        }
    }
}