using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Hospital
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new Doctor
                {
                    Id = 1,
                    Specialty = "Medicina General",
                    IdUser = 1,
                    Active = true,
                    Image = "doctor1.jpg",
                    RegistrationDate = staticDate,
                    IsDeleted = false
                },
                new Doctor
                {
                    Id = 2,
                    Specialty = "Pediatría",
                    IdUser = 2,
                    Active = true,
                    Image = "doctor2.jpg",
                    RegistrationDate = staticDate,
                    IsDeleted = false
                },
                new Doctor
                {
                    Id = 3,
                    Specialty = "Dermatología",
                    IdUser = 3,
                    Active = false,
                    Image = "doctor3.jpg",
                    RegistrationDate = staticDate,
                    IsDeleted = false
                }
            );

            builder.ToTable("Doctor", schema: "Hospital");
        }
    }
}
