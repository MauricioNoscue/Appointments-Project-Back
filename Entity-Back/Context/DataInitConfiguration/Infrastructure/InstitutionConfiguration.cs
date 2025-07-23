using Entity_Back.Models.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Context.DataInitConfiguration.Infrastructure
{
    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.HasIndex(i => i.Name).IsUnique();

            builder.HasData(
                new Institution
                {
                    Id = 10,
                    Name = "Salud Huila IPS",
                    CityId = 1,
                    Nit = "900123456-7",
                    Email = "info@saludhuila.com",
                    RegistrationDate = new DateTime(2024, 7, 22)
                },
                new Institution
                {
                    Id = 11,
                    Name = "Centro Médico Pitalito",
                    CityId = 2,
                    Nit = "900987654-3",
                    Email = "contacto@pitalitomedico.com",
                    RegistrationDate = new DateTime(2024, 7, 22)
                }
            );

            builder.ToTable("Institution", schema: "ModelInfrastructure");
        }
    }
}
