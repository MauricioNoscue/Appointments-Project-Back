using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models.Review
{
    public class DoctorReview : BaseModel
    {
        public int DoctorId { get; set; }           // Doctor evaluado
        public int UserId { get; set; }             // Paciente que hace la reseña

        public int Rating { get; set; }             // 1 a 5 estrellas
        public string? Comment { get; set; }        // Texto opcional

        public int? CitationId { get; set; }        // Relación con la cita
        public Citation? Citation { get; set; }     // Navegación

        // Relaciones
        public Doctor Doctor { get; set; }
        public User User { get; set; }
    }

}
