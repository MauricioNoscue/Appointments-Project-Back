using Entity_Back.Models;

namespace Entity_Back
{
    public class ScheduleHourListDto : BaseModel
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ProgramateDate { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }

        public int SheduleId { get; set; }
    }
}