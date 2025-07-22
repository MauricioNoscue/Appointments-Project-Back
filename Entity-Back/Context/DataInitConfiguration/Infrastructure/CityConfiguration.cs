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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasData(
                new City { Id = 1, Name = "Acevedo", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 2, Name = "Aipe", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 3, Name = "Algeciras", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 4, Name = "Altamira", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 5, Name = "Baraya", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 6, Name = "Campoalegre", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 7, Name = "Colombia", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 8, Name = "Elías", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 9, Name = "Garzón", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 10, Name = "Gigante", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 11, Name = "Guadalupe", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 12, Name = "Hobo", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 13, Name = "Íquira", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 14, Name = "Isnos", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 15, Name = "La Argentina", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 16, Name = "La Plata", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 17, Name = "Nátaga", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 18, Name = "Neiva", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 19, Name = "Oporapa", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 20, Name = "Paicol", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 21, Name = "Palermo", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 22, Name = "Palestina", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 23, Name = "Pital", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 24, Name = "Pitalito", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 25, Name = "Rivera", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 26, Name = "Saladoblanco", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 27, Name = "San Agustín", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 28, Name = "Santa María", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 29, Name = "Suaza", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 30, Name = "Tarqui", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 31, Name = "Tello", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 32, Name = "Teruel", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 33, Name = "Tesalia", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 34, Name = "Timaná", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 35, Name = "Villavieja", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) },
                new City { Id = 36, Name = "Yaguará", DepartamentId = 1, RegistrationDate = new DateTime(2024, 7, 22) }
            );

            builder.ToTable("City", schema: "ModelInfrastructure");
        }
    }
}

