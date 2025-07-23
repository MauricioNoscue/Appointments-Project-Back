using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Medical
{
    public class SheduleConfiguration : IEntityTypeConfiguration<Shedule>
    {
        public void Configure(EntityTypeBuilder<Shedule> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new Shedule
                {
                    Id = 1,
                    TypeCitationId = 1, // Consulta General
                    DoctorId = 1,       // Dr. Medicina General
                    ConsultingRoomId = 1, // Consultorio General
                    NumberCitation = 4,
                    SheduleId = null,
                    RegistrationDate = staticDate,
                    IsDeleted = false
                },
                new Shedule
                {
                    Id = 2,
                    TypeCitationId = 2, // Odontología
                    DoctorId = 2,       // Dr. Odontólogo
                    ConsultingRoomId = 2, // Sala Odontología
                    NumberCitation = 6,
                    SheduleId = null,
                    RegistrationDate = staticDate,
                    IsDeleted = false
                },
                new Shedule
                {
                    Id = 3,
                    TypeCitationId = 3, // Laboratorio
                    DoctorId = 3,       // Dr. Inactivo (por ejemplo)
                    ConsultingRoomId = 3, // Laboratorio Clínico
                    NumberCitation = 8,
                    SheduleId = null,
                    RegistrationDate = staticDate,
                    IsDeleted = false
                }
            );

            builder.ToTable("Shedule", schema: "Medical");
        }
    }
}
