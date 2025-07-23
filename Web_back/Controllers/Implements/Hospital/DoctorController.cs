using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class DoctorController : ControllerGeneric<DoctorCreateDto, DoctorEditDto, DoctorListDto>
    {
        public DoctorController(
            IBaseModelBusiness<DoctorCreateDto, DoctorEditDto, DoctorListDto> service,
            ILogger<DoctorController> logger)
            : base(service, logger)
        {
        }
    }
}
