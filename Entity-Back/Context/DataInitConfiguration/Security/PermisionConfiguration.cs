using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Security
{
    public class PermisionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            // Índice único para evitar duplicados en el nombre
            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasData(
                new Permission
                {
                    Id = 1,
                    Name = "Mostrar",
                    Description = "Permite ver un registro",
                    RegistrationDate = new DateTime(2024, 7, 16)
                },
                new Permission
                {
                    Id = 2,
                    Name = "VerTodo",
                    Description = "Permite ver todos los registros (solo Admin)",
                    RegistrationDate = new DateTime(2024, 7, 16)
                },
                new Permission
                {
                    Id = 3,
                    Name = "Crear",
                    Description = "Permite crear registros",
                    RegistrationDate = new DateTime(2024, 7, 16)
                },
                new Permission
                {
                    Id = 4,
                    Name = "Editar",
                    Description = "Permite editar registros",
                    RegistrationDate = new DateTime(2024, 7, 16)
                },
                new Permission
                {
                    Id = 5,
                    Name = "Eliminar",
                    Description = "Permite eliminar registros",
                    RegistrationDate = new DateTime(2024, 7, 16)
                }
            );

            builder.ToTable("Permission", schema: "ModelSecurity");
        }
    }
}
