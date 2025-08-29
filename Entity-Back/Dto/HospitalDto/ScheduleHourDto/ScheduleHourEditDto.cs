using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class ScheduleHourEditDto
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Id válido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria")]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "La fecha programada es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime ProgramateDate { get; set; }

        public TimeSpan? BreakStartTime { get; set; }

        public TimeSpan? BreakEndTime { get; set; }
    }

}