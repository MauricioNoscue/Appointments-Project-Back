using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.RolDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class PersonController : ControllerGeneric<PersonCreatedDto, PersonEditDto, PersonListDto>
    {
        public PersonController(IBaseModelBusiness<PersonCreatedDto, PersonEditDto, PersonListDto> service, ILogger<PersonController> logger) :
            base(service, logger)
        {

        }
    }
}
