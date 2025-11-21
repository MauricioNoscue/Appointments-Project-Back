using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity_Back.Models.Status;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity_Back.Enum;


namespace Entity_Back.Context.DataInitConfiguration.StatusType
{
    public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusTypes>
    {
        public void Configure(EntityTypeBuilder<StatusTypes> builder)
        {
            builder.HasData(

                // ---------------------------
                // 📌 CATEGORY: CITATION
                // ---------------------------

                new StatusTypes
                {
                    Id = 1,
                    Name = "Programada",
                    Description = "Scheduled citation",
                    CategoryStatus = CategoryStatus.Citation,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new StatusTypes
                {
                    Id = 2,
                    Name = "Cancelada",
                    Description = "Canceled citation",
                    CategoryStatus = CategoryStatus.Citation,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new StatusTypes
                {
                    Id = 3,
                    Name = "No Asistida",
                    Description = "Missed citation",
                    CategoryStatus = CategoryStatus.Citation,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },

                new StatusTypes
                {
                    Id = 4,
                    Name = "Atendida",
                    Description = "completed citation",
                    CategoryStatus = CategoryStatus.Citation,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },

                // ---------------------------
                // 📌 CATEGORY: NOTIFICATION
                // ---------------------------

                new StatusTypes
                {
                    Id = 5,
                    Name = "Enviada",
                    Description = "Notification sent",
                    CategoryStatus = CategoryStatus.Notification,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new StatusTypes
                {
                    Id = 6,
                    Name = "Leída",
                    Description = "Notification read",
                    CategoryStatus = CategoryStatus.Notification,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },

                // ---------------------------
                // 📌 CATEGORY: REQUEST
                // ---------------------------

                new StatusTypes
                {
                    Id = 7,
                    Name = "Pendiente",
                    Description = "Request pending",
                    CategoryStatus = CategoryStatus.Request,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new StatusTypes
                {
                    Id = 8,
                    Name = "Aprobada",
                    Description = "Request approved",
                    CategoryStatus = CategoryStatus.Request,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new StatusTypes
                {
                    Id = 9,
                    Name = "Cancelada",
                    Description = "Request canceled",
                    CategoryStatus = CategoryStatus.Request,
                    IsDeleted = false,
                    RegistrationDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
