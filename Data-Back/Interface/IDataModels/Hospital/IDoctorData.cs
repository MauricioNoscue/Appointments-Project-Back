using Data_Back.Interface.IBaseModelData;
using Entity_Back;

namespace Data_Back.Interface
{
    public interface IDoctorData : IBaseModelData<Doctor>
    {
        Task<DoctorListDto?> GetDoctorWithPersonById(int id);
        Task<IEnumerable<DoctorListDto>> GetAllDoctorWithPerson();
    }
}
