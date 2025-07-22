using Entity_Back.Models;

namespace Entity_Back
{
    public class DoctorListDto
    {
        public string Specialty { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string Image { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
