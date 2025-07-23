using Entity_Back.Models.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Context.DataInitConfiguration.Infrastructure
{
    class BranchConfiguration : IEntityTypeConfiguration<Branch>

    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasIndex(b => b.Name).IsUnique();

            builder.HasData(
                new Branch
                {
                    Id = 1,
                    Name = "Sucursal Neiva",
                    Email = "neiva@ips.com",
                    PhoneNumber = "3211112233",
                    Address = "Cra 7 #12-34",
                    InstitutionId = 10,
                    RegistrationDate = new DateTime(2024, 7, 22)
                },
                new Branch
                {
                    Id = 2,
                    Name = "Sucursal Pitalito",
                    Email = "pitalito@ips.com",
                    PhoneNumber = "3224445566",
                    Address = "Av Circunvalar #45",
                    InstitutionId = 10,
                    RegistrationDate = new DateTime(2024, 7, 22)
                }
            );

            builder.ToTable("Branch", schema: "ModelInfrastructure");
        }
    }
}

