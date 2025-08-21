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
                ,
                new ScheduleHour
                {
                    Id = 4,
                    StartTime = new TimeSpan(8, 0, 0),     // 08:00:00
                    EndTime = new TimeSpan(16, 0, 0),      // 16:00:00
                    ProgramateDate = new DateTime(2025, 8, 16), // 2025-08-16
                    BreakStartTime = new TimeSpan(12, 0, 0),    // 12:00:00
                    BreakEndTime = new TimeSpan(14, 0, 0),      // 14:00:00
                    SheduleId = 4,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                }

            );

            builder.ToTable("ScheduleHour", schema: "Medical");
        }
    }
}
