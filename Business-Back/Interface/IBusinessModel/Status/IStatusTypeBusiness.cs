using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.Status.StatusTypesDto;

namespace Business_Back.Interface.IBusinessModel.Status
{
    public interface IStatusTypeBusiness : IBaseModelBusiness<StatusTypeCreateDto, StatusTypeEditDto, StatusTypeListDto>
    {
    }
}
