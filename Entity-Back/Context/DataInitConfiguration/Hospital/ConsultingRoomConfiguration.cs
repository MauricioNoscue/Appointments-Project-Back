using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Hospital
{
    public class ConsultingRoomConfiguration : IEntityTypeConfiguration<ConsultingRoom>
    {
        public void Configure(EntityTypeBuilder<ConsultingRoom> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new ConsultingRoom
                {
                    Id = 1,
                    Name = "Consultorio General",
                    RoomNumber = 101,
                    Floor = 1,
                    BranchId = 1,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new ConsultingRoom
                {
                    Id = 2,
                    Name = "Pediatría",
                    RoomNumber = 202,
                    Floor = 2,
                    BranchId = 1,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new ConsultingRoom
                {
                    Id = 3,
                    Name = "Dermatología",
                    RoomNumber = 303,
                    Floor = 3,
                    BranchId = 2,
                    IsDeleted = false,
                    RegistrationDate = staticDate
                }
            );

            builder.ToTable("ConsultingRoom", schema: "Hospital");
        }
    }
}
