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
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            var staticDate = new DateTime(2024, 7, 16);

            builder.HasData(
                new DocumentType { Id = 1, Name = "Cédula Ciudadanía", Acronym = "CC", RegistrationDate = staticDate },
                new DocumentType { Id = 2, Name = "Tarjeta Identidad", Acronym = "TI", RegistrationDate = staticDate },
                new DocumentType { Id = 3, Name = "Registro Civil", Acronym = "RC", RegistrationDate = staticDate },
                new DocumentType { Id = 4, Name = "Tarjeta de Extranjería", Acronym = "TE", RegistrationDate = staticDate },
                new DocumentType { Id = 5, Name = "Pasaporte", Acronym = "PP", RegistrationDate = staticDate },
                new DocumentType { Id = 6, Name = "Permiso Especial de Permanencia", Acronym = "PEP", RegistrationDate = staticDate }
            );

            builder.ToTable("DocumentType", schema: "Hospital");

        }
    }
}
