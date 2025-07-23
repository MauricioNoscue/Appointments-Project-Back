namespace Entity_Back
{
    public class DoctorCreateDto
    {
        public string Specialty { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; } = string.Empty;
        public string EmailDoctor { get; set; }

    }
}
