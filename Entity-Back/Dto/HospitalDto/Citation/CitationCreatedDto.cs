using Entity_Back.Models.Notification;
using Entity_Back.Models.SecurityModels;
using Entity_Back;
using System.ComponentModel.DataAnnotations;

namespace Entity_Back
{
    public class CitationCreateDto
    {
        [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "El bloque de hora es obligatorio")]
        public TimeSpan? TimeBlock { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un usuario válido")]
        public int UserId { get; set; }

        [StringLength(300, ErrorMessage = "La nota no puede superar los 300 caracteres")]
        public string Note { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un horario válido")]
        public int ScheduleHourId { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El estado debe tener entre 3 y 20 caracteres")]
        public string State { get; set; }
    }

}

