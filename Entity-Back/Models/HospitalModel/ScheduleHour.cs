using Entity_Back.Models;

namespace Entity_Back
{
    public class ScheduleHour : BaseModel
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ProgramateDate { get; set; }
        public int SheduleId { get; set; }

        public  Shedule Shedule { get; set; }
        public  List<Citation> Citations { get; set; }
    }

}