using Entity_Back.Models.Notification;
using Entity_Back.Models.SecurityModels;
using Entity_Back;

namespace Entity_Back
{
    public class CitationCreateDto
    {
        public DateTime AppointmentDate { get; set; }
        public TimeSpan? TimeBlock { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public int ScheduleHourId { get; set; }
        public string State { get; set; }


    }
}

