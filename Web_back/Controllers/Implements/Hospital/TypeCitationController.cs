using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class TypeCitationController : ControllerGeneric<TypeCitationCreateDto, TypeCitationEditDto, TypeCitationListDto>
    {
        public TypeCitationController(
            IBaseModelBusiness<TypeCitationCreateDto, TypeCitationEditDto, TypeCitationListDto> service,
            ILogger<TypeCitationController> logger)
            : base(service, logger)
        {
        }
    }
}
