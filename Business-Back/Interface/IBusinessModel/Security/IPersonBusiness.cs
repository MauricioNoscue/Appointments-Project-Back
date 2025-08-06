using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Dto.SecurityDto.PersonDto;

namespace Business_Back.Interface.IBusinessModel.Security
{
    public interface IPersonBusiness : IBaseModelBusiness<PersonCreatedDto,PersonEditDto,PersonListDto>
    {
    }
}
