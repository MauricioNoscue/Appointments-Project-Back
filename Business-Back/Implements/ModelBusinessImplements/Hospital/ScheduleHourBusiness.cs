using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    public class ScheduleHourBusiness : BaseModelBusinessIm<ScheduleHour, ScheduleHourCreateDto, ScheduleHourEditDto, ScheduleHourListDto>, IScheduleHourBusiness
    {
        private readonly IScheduleHourData _data;

        public ScheduleHourBusiness(IConfiguration configuration, IScheduleHourData data, ILogger<ScheduleHourBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
