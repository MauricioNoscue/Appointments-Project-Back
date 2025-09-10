using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.HospitalDto.RelatedPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Interface.IBusinessModel.Hospital
{
    public interface IRelatedPersonBusiness : IBaseModelBusiness<RelatedPersonCreatedDto, RelatedPersonEditDto, RelatedPersonListDto>
    {
        Task<List<RelatedPersonListDto>> GetByPersonAsync(int personId);
    }
}
