namespace Entity_Back
{
    public class SheduleEditDto
    {
        public int Id { get; set; }
        public int TypeCitationId { get; set; }
        public int DoctorId { get; set; }
        public int ConsultingRoomId { get; set; }
        public int NumberCitation { get; set; }
        public int? SheduleId { get; set; }
    }
}