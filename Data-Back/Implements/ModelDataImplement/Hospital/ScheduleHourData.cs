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

        public async Task<ScheduleHour?> GetByDateAndSheduleAsync(int sheduleId)
        {
            try
            {
                return await _context.Set<ScheduleHour>()
           .Where(e => !e.IsDeleted && e.SheduleId == sheduleId)
           .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener ScheduleHour: {ex.Message}", ex);
            }
        }

    }
}
