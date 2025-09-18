using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.HospitalModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Hospital
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            var staticDate = new DateTime(2024, 07, 16);

            builder.HasData(
                new Specialty { Id = 1, Name = "Medicina General", Description = "Atención médica general y preventiva", RegistrationDate = staticDate },
                new Specialty { Id = 2, Name = "Medicina Interna", Description = "Especialidad médica para adultos", RegistrationDate = staticDate },
                new Specialty { Id = 3, Name = "Pediatría", Description = "Especialidad médica para niños", RegistrationDate = staticDate },
                new Specialty { Id = 4, Name = "Ginecología y Obstetricia", Description = "Especialidad en salud de la mujer y embarazo", RegistrationDate = staticDate },
                new Specialty { Id = 5, Name = "Cardiología", Description = "Especialidad en enfermedades del corazón", RegistrationDate = staticDate },
                new Specialty { Id = 6, Name = "Dermatología", Description = "Especialidad en enfermedades de la piel", RegistrationDate = staticDate },
                new Specialty { Id = 7, Name = "Oftalmología", Description = "Especialidad en enfermedades de los ojos", RegistrationDate = staticDate },
                new Specialty { Id = 8, Name = "Otorrinolaringología", Description = "Especialidad en oído, nariz y garganta", RegistrationDate = staticDate },
                new Specialty { Id = 9, Name = "Psiquiatría", Description = "Especialidad en salud mental", RegistrationDate = staticDate },
                new Specialty { Id = 10, Name = "Cirugía General", Description = "Especialidad en procedimientos quirúrgicos", RegistrationDate = staticDate },
                new Specialty { Id = 11, Name = "Traumatología", Description = "Especialidad en lesiones óseas y musculares", RegistrationDate = staticDate },
                new Specialty { Id = 12, Name = "Neurología", Description = "Especialidad en enfermedades del sistema nervioso", RegistrationDate = staticDate },
                new Specialty { Id = 13, Name = "Urología", Description = "Especialidad en sistema urinario", RegistrationDate = staticDate },
                new Specialty { Id = 14, Name = "Endocrinología", Description = "Especialidad en glándulas y hormonas", RegistrationDate = staticDate },
                new Specialty { Id = 15, Name = "Nefrología", Description = "Especialidad en riñones", RegistrationDate = staticDate },
                new Specialty { Id = 16, Name = "Hematología", Description = "Especialidad en sangre", RegistrationDate = staticDate },
                new Specialty { Id = 17, Name = "Oncología", Description = "Especialidad en cáncer", RegistrationDate = staticDate },
                new Specialty { Id = 18, Name = "Radiología", Description = "Especialidad en imágenes médicas", RegistrationDate = staticDate },
                new Specialty { Id = 19, Name = "Anestesiología", Description = "Especialidad en anestesia", RegistrationDate = staticDate },
                new Specialty { Id = 20, Name = "Medicina Familiar", Description = "Atención médica familiar integral", RegistrationDate = staticDate }
            );

            builder.ToTable("Specialty", schema: "Hospital");
        }
    }
}