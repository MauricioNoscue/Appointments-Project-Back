using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class EpsEditDto
    {
        [Required(ErrorMessage = "El Id de la EPS es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la EPS es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;
    }
}