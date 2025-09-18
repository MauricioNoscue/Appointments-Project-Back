using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class DocumentTypeCreatedDto
    {
        [Required(ErrorMessage = "El nombre del tipo de documento es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El acrónimo es obligatorio")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El acrónimo debe tener entre 1 y 10 caracteres")]
        public string Acronym { get; set; } = string.Empty;
    }
}