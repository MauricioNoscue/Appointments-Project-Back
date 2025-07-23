using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.InfrastructureDto.BranchDto;
using Entity_Back.Dto.InfrastructureDto.InstitutionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Interface.IBusinessModel.Infrastructure
{
    public interface IInstitutionBusiness : IBaseModelBusiness<InstitutionCreatedDto, InstitutionEditDto, InstitutionListDto>
    {
    }
}
