using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class DoctorCreateDto
    {
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una especialidad válida")]
        public int SpecialtyId { get; set; }

        public int PersonId { get; set; }


        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Active { get; set; }

        public string Image { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo del doctor es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no v�lido")]
        [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres")]
        public string EmailDoctor { get; set; } = string.Empty;
    }

}
