using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.SecurityDto.FormDto;

namespace Business_Back.Interface.IBusinessModel.Security
{
    public interface IFormBusiness : IBaseModelBusiness<FormCreatedDto, FormEditDto, FormListDto>
    {
    }

}
