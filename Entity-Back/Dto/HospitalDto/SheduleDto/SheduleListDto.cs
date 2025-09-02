using Entity_Back.Models;

namespace Entity_Back
{
    public class SheduleListDto : BaseModel
    {
        public string TypeCitationName { get; set; }
        public string NameDoctor { get; set; } = string.Empty;
        public string ConsultingRoomName { get; set; }
        public int NumberCitation { get; set; }
  
        public int RoomNumber { get; set; }
    }
}