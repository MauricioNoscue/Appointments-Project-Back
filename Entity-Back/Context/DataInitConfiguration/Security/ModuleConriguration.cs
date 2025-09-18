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
    public class ModuleConriguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            // Comentario (ES): Índice único en Name por consistencia
            builder.HasIndex(m => m.Name).IsUnique();

            builder.HasData(
                 new Module
                 {
                     Id = 1,
                     Name = "Inicio",
                     Description = "Módulo de panel principal",
                     Icon = "home",
                     RegistrationDate = new DateTime(2024, 7, 16)
                 },
                 new Module
                 {
                     Id = 2,
                     Name = "Seguridad",
                     Description = "Módulo de seguridad (roles/usuarios/permisos)",
                     Icon = "security",
                     RegistrationDate = new DateTime(2024, 7, 16)
                 },
                 new Module
                 {
                     Id = 3,
                     Name = "Citas",
                     Description = "Módulo de citas (consultorios/horarios/tipos)",
                     Icon = "calendar_month",
                     RegistrationDate = new DateTime(2024, 7, 16)
                 },
                 new Module
                 {
                     Id = 4,
                     Name = "Parámetros",
                     Description = "Catálogos y parámetros del sistema",
                     Icon = "tune",
                     RegistrationDate = new DateTime(2024, 7, 16)
                 },
                     new Module
                     {
                         Id = 5,
                         Name = "Paciente",
                         Description = "Catálogos y parámetros del sistema",
                         Icon = "tune",
                         RegistrationDate = new DateTime(2024, 7, 16)
                     }, new Module
                     {
                         Id = 6,
                         Name = "Doctor",
                         Description = "Catálogos y parámetros del sistema",
                         Icon = "tune",
                         RegistrationDate = new DateTime(2024, 7, 16)
                     }
             );


            builder.ToTable("Module", schema: "ModelSecurity");
        }
    }
}
