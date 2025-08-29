using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class TypeCitationCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 50 caracteres")]
        public string Description { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "El icono no puede superar los 50 caracteres")]
        public string Icon { get; set; } = string.Empty;
    }

}