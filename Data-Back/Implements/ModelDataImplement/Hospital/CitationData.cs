using Data_Back.Implements.BaseModelData;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    public class CitationsData : BaseModelData<Citation>, ICitationsData
    {
        private readonly ApplicationDbContext _context;

        public CitationsData(ApplicationDbContext context, ILogger<BaseModelData<Citation>> logger)
            : base(context, logger)
        {
            _context = context;
        }
        public async Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate)
        {
            return await _context.Set<Citation>()
                .Where(c => c.ScheduleHourId == scheduleHourId &&
                            c.AppointmentDate.Date == appointmentDate.Date &&
                            !c.IsDeleted )
                .Select(c => c.TimeBlock.Value)
                .ToListAsync();
        }

    }
}