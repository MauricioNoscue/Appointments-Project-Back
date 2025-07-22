namespace Entity_Back
{
    public class DoctorEditDto
    {
        public int Id { get; set; }
        public string Specialty { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}