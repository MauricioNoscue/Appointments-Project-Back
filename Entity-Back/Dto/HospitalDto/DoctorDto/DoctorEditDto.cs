using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class DoctorEditDto
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id v�lido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una especialidad válida")]
        public int SpecialtyId { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un usuario v�lido")]
        public int PersonId { get; set; }


        [StringLength(250, ErrorMessage = "La URL de la imagen no puede superar los 250 caracteres")]
        public string Image { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo del doctor es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no v�lido")]
        [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres")]
        public string EmailDoctor { get; set; }
    }

}