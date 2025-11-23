using Data_Back.Interface.IBaseModelData;
using Entity_Back;

namespace Data_Back.Interface
{
    public interface ISheduleData : IBaseModelData<Shedule>
    {
        Task<Shedule?> GetByIdTypeCitation(int id);
        Task<Shedule?> GetByDoctorAndDateAsync(int doctorId, DateTime date);

    }
}
