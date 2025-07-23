using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.InfrastructureDto.CityDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Infrastructure
{

    public class CityController : ControllerGeneric<CityCreatedDto, CityEditDto, CityListDto>
    {
        public CityController(IBaseModelBusiness<CityCreatedDto, CityEditDto, CityListDto> service,
                              ILogger<CityController> logger)
            : base(service, logger)
        {
        }
    }
}
