using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;

namespace Business_Back
{
    public interface ICitationsBusiness : IBaseModelBusiness<CitationCreateDto, CitationEditDto, CitationListDto>
    {
        Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate);

    }
}


