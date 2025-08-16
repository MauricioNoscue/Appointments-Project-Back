using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;

namespace Business_Back
{
    public interface ISheduleBusiness : IBaseModelBusiness<SheduleCreateDto, SheduleEditDto, SheduleListDto>
    {
        Task<SheduleListDto?> GetByIdTypeCitation(int id);

    }
}
