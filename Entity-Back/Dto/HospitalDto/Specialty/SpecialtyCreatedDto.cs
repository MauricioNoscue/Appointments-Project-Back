using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class SpecialtyCreatedDto
    {
        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 500 caracteres")]
        public string Description { get; set; } = string.Empty;
    }
}