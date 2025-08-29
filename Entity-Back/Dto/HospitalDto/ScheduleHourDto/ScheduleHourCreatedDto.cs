using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class ScheduleHourCreateDto
    {
        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria")]
        public TimeSpan EndTime { get; set; }

        public TimeSpan? BreakStartTime { get; set; }

        public TimeSpan? BreakEndTime { get; set; }

        [Required(ErrorMessage = "La fecha programada es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime ProgramateDate { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un horario válido")]
        public int SheduleId { get; set; }
    }

}