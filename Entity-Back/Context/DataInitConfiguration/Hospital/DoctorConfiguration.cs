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
                    SpecialtyId = 1, // Medicina General
                    PersonId = 1,
                    Active = true,
                    Image = "doctor1.jpg",
                    RegistrationDate = staticDate,
                    IsDeleted = false,
                    EmailDoctor = "doctor@gmail.com"
                },
                new Doctor
                {
                    Id = 2,
                    SpecialtyId = 3, // Pediatría
                    PersonId = 2,
                    Active = true,
                    Image = "doctor2.jpg",
                    RegistrationDate = staticDate,
                    IsDeleted = false
                },
                new Doctor
                {
                    Id = 3,
                    SpecialtyId = 6, // Dermatología
                    PersonId = 1,
                    Active = false,
                    Image = "doctor3.jpg",
                    RegistrationDate = staticDate,
                    IsDeleted = false,
                    EmailDoctor = "docto2r@gmail.com"

                //}
            );

            builder.ToTable("Doctor", schema: "Hospital");
        }
    }
}
