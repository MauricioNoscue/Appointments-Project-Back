using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class SheduleCreateDto
    {
        [Required(ErrorMessage = "El tipo de cita es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de cita v�lido")]
        public int TypeCitationId { get; set; }

        [Required(ErrorMessage = "El doctor es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un doctor v�lido")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "El consultorio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un consultorio v�lido")]
        public int ConsultingRoomId { get; set; }

        [Required(ErrorMessage = "El n�mero de citas es obligatorio")]
        [Range(1, 500, ErrorMessage = "El n�mero de citas debe estar entre 1 y 500")]
        public int NumberCitation { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un horario v�lido")]
        public int SheduleId { get; set; }
    }

}