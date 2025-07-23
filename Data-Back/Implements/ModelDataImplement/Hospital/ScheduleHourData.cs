using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class ScheduleHourData : BaseModelData<ScheduleHour>, IScheduleHourData
    {
        public ScheduleHourData(ApplicationDbContext context, ILogger<BaseModelData<ScheduleHour>> logger)
            : base(context, logger)
        {
        }
    }
}
