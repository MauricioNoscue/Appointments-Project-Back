using Business_Back.Implements.BaseModelBusiness;
using Data_Back;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    public class CitationBusiness : BaseModelBusinessIm<Citation, CitationCreateDto, CitationEditDto, CitationListDto>, ICitationsBusiness
    {
        private readonly ICitationsData _data;

        public CitationBusiness(IConfiguration configuration, ICitationsData data, ILogger<CitationBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        public async Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate)
        {
            return await _data.GetUsedTimeBlocksByScheduleHourIdAndDateAsync(scheduleHourId, appointmentDate);
        }

    }
}

