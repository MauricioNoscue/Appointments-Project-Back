using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Entity_Back.Dto.HospitalDto.DoctorDto;

namespace Business_Back
{
    public interface IDoctorBusiness : IBaseModelBusiness<DoctorCreateDto, DoctorEditDto, DoctorListDto>
    {
        Task<IEnumerable<DoctorListDto>> GetAllDoctorWithPerson();
        Task<DoctorListDto?> GetDoctorWithPersonById(int id);
        // Método para obtener citas asignadas a un doctor
        Task<IEnumerable<CitationListDto>> GetCitationsByDoctorId(int doctorId);

        Task<DoctorReviewAll?> GetDoctorWithReviewsAsync(int doctorId);
    }
}
