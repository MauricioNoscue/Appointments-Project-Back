using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back
{
    public class ScheduleHourConfiguration : IEntityTypeConfiguration<ScheduleHour>
    {
        public void Configure(EntityTypeBuilder<ScheduleHour> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new ScheduleHour
                {
                    Id = 1,
                    StartTime = new TimeSpan(08, 00, 00),
                    EndTime = new TimeSpan(08, 30, 00),
                    ProgramateDate = staticDate.AddDays(1),
                    SheduleId = 1,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new ScheduleHour
                {
                    Id = 2,
                    StartTime = new TimeSpan(08, 30, 00),
                    EndTime = new TimeSpan(09, 00, 00),
                    ProgramateDate = staticDate.AddDays(1),
                    SheduleId = 1,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new ScheduleHour
                {
                    Id = 3,
                    StartTime = new TimeSpan(09, 00, 00),
                    EndTime = new TimeSpan(09, 30, 00),
                    ProgramateDate = staticDate.AddDays(2),
                    SheduleId = 2,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                }
            );

            builder.ToTable("ScheduleHour", schema: "Medical");
        }
    }
}
