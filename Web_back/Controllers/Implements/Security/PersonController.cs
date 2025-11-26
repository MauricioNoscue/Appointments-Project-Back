using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Microsoft.AspNetCore.Mvc;
using Utilities_Back.Exceptions;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class PersonController : ControllerGeneric<PersonCreatedDto, PersonEditDto, PersonListDto>
    {
        private readonly IPersonBusiness _serviceperson;
        public PersonController(IBaseModelBusiness<PersonCreatedDto, PersonEditDto, PersonListDto> service, ILogger<PersonController> logger, IPersonBusiness serviceperson) :
            base(service, logger)
        {
            _serviceperson = serviceperson;
        }



    }
}
