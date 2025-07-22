using Entity_Back.Models;

namespace Entity_Back
{
    public class SheduleListDto : BaseModel
    {
        public int TypeCitationId { get; set; }
        public string NameDoctor { get; set; } = string.Empty;
        public int ConsultingRoomId { get; set; }
        public int NumberCitation { get; set; }
        public int? SheduleId { get; set; }
    }
}