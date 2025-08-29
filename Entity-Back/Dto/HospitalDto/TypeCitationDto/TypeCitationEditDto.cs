using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class TypeCitationEditDto
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 50 caracteres")]
        public string? Description { get; set; } = string.Empty; // opcional, pero validada si llega

        [StringLength(50, ErrorMessage = "El icono no puede superar los 50 caracteres")]
        public string? Icon { get; set; } = string.Empty;
    }

}