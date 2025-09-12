using Data_Back.Interface.IBaseModelData;
using Entity_Back;

namespace Data_Back.Interface
{
    public interface IDoctorData : IBaseModelData<Doctor>
    {
        Task<DoctorListDto?> GetDoctorWithPersonById(int id);
        Task<IEnumerable<DoctorListDto>> GetAllDoctorWithPerson();
        // Método para obtener citas asignadas a un doctor
        Task<IEnumerable<CitationListDto>> GetCitationsByDoctorId(int doctorId);
    }
}
