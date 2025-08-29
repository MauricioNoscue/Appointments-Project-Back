using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class ConsultingRoomEditDto
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de sala es obligatorio")]
        [Range(1, 9999, ErrorMessage = "El número de sala debe estar entre 1 y 9999")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "El piso es obligatorio")]
        [Range(0, 100, ErrorMessage = "El piso debe estar entre 0 y 100")]
        public int Floor { get; set; }
    }

}