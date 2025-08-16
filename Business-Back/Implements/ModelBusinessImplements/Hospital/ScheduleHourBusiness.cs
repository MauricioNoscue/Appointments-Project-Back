using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Mapster;
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

        public async Task<ScheduleHourListDto?> GetByIdShedule(int id)
        {
            try
            {
                if(id <= 0)
                {
                    throw new ArgumentException("ScheduleId must be greater than zero.", nameof(id));
                }

                var sheduleHour = await _data.GetByIdShedule(id);
                return sheduleHour.Adapt<ScheduleHourListDto>();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                throw new Exception($"Error retrieving ScheduleHours by ScheduleId {id}: {ex.Message}", ex);
            }
        }
    }
}
