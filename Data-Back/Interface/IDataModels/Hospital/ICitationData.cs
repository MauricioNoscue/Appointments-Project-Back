using Data_Back.Interface.IBaseModelData;
using Entity_Back;

namespace Data_Back
{
    public interface ICitationsData : IBaseModelData<Citation>
    {
        Task<List<Citation>> GetAllForListAsync(int userId);
        Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate);

        Task<List<Citation>> GetCitationsByDoctorAndDate(int doctorId, DateTime date);

        Task<IEnumerable<Citation>> GetCitationsByDoctor(int doctorId, DateTime date);

        Task<List<Citation>> GetCitationsForDashboardAsync(int doctorId);

    }
}


