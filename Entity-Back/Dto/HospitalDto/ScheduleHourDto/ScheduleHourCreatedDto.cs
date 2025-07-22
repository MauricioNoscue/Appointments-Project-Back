namespace Entity_Back
{
    public class ScheduleHourCreateDto
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ProgramateDate { get; set; }
        public int SheduleId { get; set; }
    }
}