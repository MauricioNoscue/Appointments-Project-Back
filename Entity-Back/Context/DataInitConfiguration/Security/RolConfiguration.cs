using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entity_Back.Context.DataInitConfiguration.Security
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {

            builder.HasIndex(f => f.Name).IsUnique();
       

            builder.HasData(
          new Rol
          {
              Id = 1,
              Name = "Admin",
              Description = "Rol de administrador",
              RegistrationDate = new DateTime(2024, 7, 16)
          },
          new Rol
          {
              Id = 2,
              Name = "Usuario",
              Description = "Rol estándar",
              RegistrationDate = new DateTime(2024, 7, 16)
          }
      );


            builder.ToTable("Rol", schema: "ModelSecurity");
        }
    }
}
