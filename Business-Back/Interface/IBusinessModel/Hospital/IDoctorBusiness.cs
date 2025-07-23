using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;

namespace Business_Back
{
    public interface IDoctorBusiness : IBaseModelBusiness<DoctorCreateDto, DoctorEditDto, DoctorListDto>
    {
    }
}
