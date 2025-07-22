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
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.HasIndex(d => d.Name).IsUnique();

            builder.HasData(
                new Departament { Id = 1, Name = "Huila", RegistrationDate = new DateTime(2024, 7, 22) },
            );

            builder.ToTable("Departament", schema: "ModelInfrastructure");
        }
    }
}
