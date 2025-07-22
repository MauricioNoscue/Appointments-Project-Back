using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back
{
    public class CitationConfiguration : IEntityTypeConfiguration<Citation>
    {
        public void Configure(EntityTypeBuilder<Citation> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new Citation
                {
                    Id = 1,
                    UserId = 1,
                    CreationDate = staticDate,
                    State = "Pendiente",
                    Note = "Cita para revisión general",
                    ScheduleHourId = 1,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new Citation
                {
                    Id = 2,
                    UserId = 2,
                    CreationDate = staticDate.AddHours(1),
                    State = "Confirmada",
                    Note = "Control postoperatorio",
                    ScheduleHourId = 2,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                }
            );

            builder.ToTable("Citation", schema: "Medical");
        }
    }

}

