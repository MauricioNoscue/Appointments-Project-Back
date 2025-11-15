using Entity_Back.Models;
using Entity_Back.Models.Notification;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back
{
    public class Citation : BaseModel
    {
        public int UserId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan? TimeBlock { get; set; }
        public string State { get; set; }
        public string Note { get; set; }
        public int ScheduleHourId { get; set; }
        public int? ReltedPersonId { get; set; }

        public  User User { get; set; }
       
        public  ScheduleHour ScheduleHour { get; set; }
    }

}