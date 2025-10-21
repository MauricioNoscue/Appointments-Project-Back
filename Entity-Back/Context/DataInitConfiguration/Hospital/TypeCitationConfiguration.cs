using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Hospital
{
    public class TypeCitationConfiguration : IEntityTypeConfiguration<TypeCitation>
    {
        public void Configure(EntityTypeBuilder<TypeCitation> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new TypeCitation
                {
                    Id = 1,
                    Name = "Consulta General",
                    Description = "Evaluación médica básica con revisión general del paciente.",
                    Icon = "general.png",
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new TypeCitation
                {
                    Id = 2,
                    Name = "Odontología",
                    Description = "Atención en salud bucal, limpieza, diagnósticos y tratamientos.",
                    Icon = "odontologia.png",
                    IsDeleted = false,
                    RegistrationDate = staticDate
                },
                new TypeCitation
                {
                    Id = 3,
                    Name = "Pediatría",
                    Description = "Citas para toma de muestras y análisis clínicos.",
                    Icon = "pediatria.png",
                    IsDeleted = false,
                    RegistrationDate = staticDate
                }
                ,
                new TypeCitation
                {
                    Id = 4,
                    Name = "Consulta Externa",
                    Description = "Citas para toma de muestras y análisis clínicos.",
                    Icon = "CExterna.png",
                    IsDeleted = false,
                    RegistrationDate = staticDate
                }
            );

            builder.ToTable("TypeCitation", schema: "Hospital");
        }
    }
}
