using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class CitationEditDto
    {
        [Required(ErrorMessage = "El Id de la cita es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id v�lido")]
        public int Id { get; set; }

        public int StatustypesId { get; set; }

        [StringLength(1000, ErrorMessage = "La nota no puede superar los 300 caracteres")]
        public string? Note { get; set; } = string.Empty;

        public int? ReltedPersonId { get; set; }

    }

}