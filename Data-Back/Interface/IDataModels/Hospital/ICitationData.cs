using Data_Back.Interface.IBaseModelData;
using Entity_Back;

namespace Data_Back
{
    public interface ICitationsData : IBaseModelData<Citation>
    {
        Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate);
    }
}


