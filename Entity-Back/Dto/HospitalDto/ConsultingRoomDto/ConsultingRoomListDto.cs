using Entity_Back.Models;

namespace Entity_Back
{
    public class ConsultingRoomListDto : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int? BranchId { get; set; }
    }
}
