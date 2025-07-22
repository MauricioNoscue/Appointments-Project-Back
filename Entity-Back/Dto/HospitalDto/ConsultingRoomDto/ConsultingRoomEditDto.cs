namespace Entity_Back
{
    public class ConsultingRoomEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
    }
}