using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.ReviewDto.DoctorReviewDto;

namespace Entity_Back.Dto.HospitalDto.DoctorDto
{
    public class DoctorReviewAll
    {
        // Datos del doctor ----------------------------
        public int Id { get; set; }                      // Id del doctor
        public bool Active { get; set; }                 // Estado activo/inactivo
        public string? EmailDoctor { get; set; }         // Email del doctor
        public string Image { get; set; } = string.Empty; // Imagen del doctor

        // Datos de la especialidad ---------------------
        public int SpecialtyId { get; set; }             // Id de la especialidad
        public string SpecialtyName { get; set; }        // Nombre de la especialidad
        public string SpecialtyDescription { get; set; } // Descripción de la especialidad

        // Datos básicos de la persona ------------------
        public int PersonId { get; set; }                // Id de la persona
        public string FullName { get; set; }             // Nombre completo
        public string FullLastName { get; set; }         // Apellidos
        public string Document { get; set; }             // Documento
        public string PhoneNumber { get; set; }          // Teléfono
        public DateTime DateBorn { get; set; }           // Fecha de nacimiento
        public string? Address { get; set; }             // Dirección

        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public Dictionary<int, int> RatingsDistribution { get; set; } = new();


        // Reseñas --------------------------------------
        public List<DoctorReviewListDto> Reviews { get; set; } = new(); // Lista de reseñas
    }
}
