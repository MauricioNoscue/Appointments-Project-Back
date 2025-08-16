using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class ScheduleHourData : BaseModelData<ScheduleHour>, IScheduleHourData
    {
        private readonly ApplicationDbContext _context;
        public ScheduleHourData(ApplicationDbContext context, ILogger<BaseModelData<ScheduleHour>> logger)
            : base(context, logger)
        {
            _context = context;
        }

        public async Task<ScheduleHour?> GetByIdShedule(int id)
        {
            try
            {
                var ltsModel = await _context.Set<ScheduleHour>()
                .Where(e => !e.IsDeleted && e.SheduleId == id)
                .FirstOrDefaultAsync();
                return ltsModel;
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                throw new Exception($"Error retrieving ScheduleHours by ScheduleId {id}: {ex.Message}", ex);
            }

        }
    }
}
