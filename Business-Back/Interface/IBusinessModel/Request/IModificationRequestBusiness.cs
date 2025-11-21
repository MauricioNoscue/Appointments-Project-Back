using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.RequestDto;
using Entity_Back.Dto.SecurityDto.UserDto;

namespace Business_Back.Interface.IBusinessModel.Request
{
    public interface IModificationRequestBusiness : IBaseModelBusiness<ModificationRequestCreateDto, ModificationRequestEditDto, ModificationRequestListDto>
    { }
   
}
