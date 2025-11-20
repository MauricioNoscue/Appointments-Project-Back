using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class CitationEditDto
    {
        [Required(ErrorMessage = "El Id de la cita es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id v�lido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El estado debe tener entre 3 y 20 caracteres")]
        public string State { get; set; }

        [StringLength(1000, ErrorMessage = "La nota no puede superar los 300 caracteres")]
        public string? Note { get; set; } = string.Empty;

        public int? ReltedPersonId { get; set; }
        public int UserId { get; set; }


    }

}