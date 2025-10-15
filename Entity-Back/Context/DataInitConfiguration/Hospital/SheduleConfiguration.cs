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
                    Id = 4,
                    TypeCitationId = 4, // Laboratorio
                    DoctorId = 1,       // Dr. Inactivo (por ejemplo)
                    ConsultingRoomId = 3, // Laboratorio Clínico
                    NumberCitation = 24,
                    SheduleId = null,
                    RegistrationDate = staticDate,
                    IsDeleted = false
                }
            );

            builder.ToTable("Shedule", schema: "Medical");
        }
    }
}
