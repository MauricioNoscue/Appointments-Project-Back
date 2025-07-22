using Entity_Back.Models;

namespace Entity_Back
{
    public class Shedule : BaseModel
    {
        public int TypeCitationId { get; set; }
        public int DoctorId { get; set; }
        public int ConsultingRoomId { get; set; }
        public int NumberCitation { get; set; }
        public int? SheduleId { get; set; }

        public  Doctor Doctor { get; set; }
        public  TypeCitation TypeCitation { get; set; }
        public  ConsultingRoom ConsultingRoom { get; set; }
        public  List<ScheduleHour> ScheduleHours { get; set; }
    }

}