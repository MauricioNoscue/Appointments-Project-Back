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
                    Id = 2,
                    UserId = 1, 
                    AppointmentDate = new DateTime(2025, 8, 23, 17, 34, 12, 220), 
                    TimeBlock = new TimeSpan(8, 45, 0), 
                    State = "Agendada",
                    Note = "string",
                    ScheduleHourId = 1,
                    IsDeleted = false,
                    RegistrationDate = staticDate 
                }

            );

            builder.ToTable("Citation", schema: "Medical");
        }
    }

}

