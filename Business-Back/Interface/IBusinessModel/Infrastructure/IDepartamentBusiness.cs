using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.InfrastructureDto.Departament;
using Entity_Back.Dto.InfrastructureDto.DepartamentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Interface.IBusinessModel.Infrastructure
{
    public interface IDepartamentBusiness : IBaseModelBusiness<DepartamentCreatedDto, DepartamentEditDto, DepartamentListDto>
    {
    }
}
