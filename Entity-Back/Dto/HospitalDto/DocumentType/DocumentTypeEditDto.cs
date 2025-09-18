using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class DocumentTypeEditDto
    {
        [Required(ErrorMessage = "El Id del tipo de documento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de documento es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El acrónimo es obligatorio")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El acrónimo debe tener entre 1 y 10 caracteres")]
        public string Acronym { get; set; } = string.Empty;
    }
}