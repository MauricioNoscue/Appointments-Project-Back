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
    public class EpsConfiguration : IEntityTypeConfiguration<Eps>
    {
        public void Configure(EntityTypeBuilder<Eps> builder)
        {
            var staticDate = new DateTime(2024, 07, 16);

            builder.HasData(

                new Eps { Id = 1, Name = "Coosalud EPS‑S", RegistrationDate = staticDate },
                new Eps { Id = 2, Name = "Nueva EPS", RegistrationDate = staticDate },
                new Eps { Id = 3, Name = "Mutual SER", RegistrationDate = staticDate },
                new Eps { Id = 4, Name = "Salud MÍA", RegistrationDate = staticDate },
                new Eps { Id = 5, Name = "Aliansalud EPS", RegistrationDate = staticDate },
                new Eps { Id = 6, Name = "Salud Total EPS S.A.", RegistrationDate = staticDate },
                new Eps { Id = 7, Name = "EPS Sanitas", RegistrationDate = staticDate },
                new Eps { Id = 8, Name = "EPS Sura", RegistrationDate = staticDate },
                new Eps { Id = 9, Name = "Famisanar", RegistrationDate = staticDate },
                new Eps { Id = 10, Name = "Servicio Occidental de Salud – SOS", RegistrationDate = staticDate },
                new Eps { Id = 11, Name = "Comfenalco Valle", RegistrationDate = staticDate },
                new Eps { Id = 12, Name = "Compensar EPS", RegistrationDate = staticDate },
                new Eps { Id = 13, Name = "Empresas Públicas de Medellín – EPM", RegistrationDate = staticDate },
                new Eps { Id = 14, Name = "Fondo de Pasivo Social de Ferrocarriles Nacionales de Colombia", RegistrationDate = staticDate },
                new Eps { Id = 15, Name = "Cajacopi Atlántico", RegistrationDate = staticDate },
                new Eps { Id = 16, Name = "Capresoca", RegistrationDate = staticDate },
                new Eps { Id = 17, Name = "Comfachocó", RegistrationDate = staticDate },
                new Eps { Id = 18, Name = "Comfaoriente", RegistrationDate = staticDate },
                new Eps { Id = 19, Name = "EPS Familiar de Colombia", RegistrationDate = staticDate },
                new Eps { Id = 21, Name = "Emssanar E.S.S.", RegistrationDate = staticDate },
                new Eps { Id = 20, Name = "Asmet Salud", RegistrationDate = staticDate },
                new Eps { Id = 22, Name = "Capital Salud EPS‑S", RegistrationDate = staticDate },
                new Eps { Id = 23, Name = "Savia Salud EPS", RegistrationDate = staticDate },
                new Eps { Id = 24, Name = "Dusakawi EPSI", RegistrationDate = staticDate },
                new Eps { Id = 25, Name = "Asociación Indígena del Cauca EPSI", RegistrationDate = staticDate },
                new Eps { Id = 26, Name = "Anas Wayuu EPSI", RegistrationDate = staticDate },
                new Eps { Id = 27, Name = "Mallamas EPSI", RegistrationDate = staticDate },
                new Eps { Id = 28, Name = "Pijaos Salud EPSI", RegistrationDate = staticDate }
            );

            builder.ToTable("Eps", schema: "Hospital");
        }
    }
}
