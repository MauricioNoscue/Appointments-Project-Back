using Entity_Back.Models;

namespace Entity_Back
{
    public class CitationListDto : BaseModel
    {
        public int UserId { get; set; }
        public int StatustypesId { get; set; }
        public string StatustypesName { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan? TimeBlock { get; set; }
        public int ScheduleHourId { get; set; }
        public int DoctorId { get; set; }
        public string NameDoctor { get; set; }
        public string ConsultingRoomName { get; set; }
        public int RoomNumber { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public int? ReltedPersonId { get; set; }


    }
}