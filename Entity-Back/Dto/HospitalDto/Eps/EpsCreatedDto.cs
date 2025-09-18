using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class EpsCreatedDto
    {
        [Required(ErrorMessage = "El nombre de la EPS es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;
    }
}