using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class DoctorCreateDto
    {
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La especialidad debe tener entre 3 y 100 caracteres")]
        public string Specialty { get; set; } = string.Empty;

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un usuario válido")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Active { get; set; }

        [StringLength(250, ErrorMessage = "La URL de la imagen no puede superar los 250 caracteres")]
        public string Image { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo del doctor es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres")]
        public string EmailDoctor { get; set; }
    }

}
