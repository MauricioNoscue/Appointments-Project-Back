using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entity_Back.Context.DataInitConfiguration.Security
{
    // rama mauro
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // rama mauro 
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasData(
               new User
               {
                   Id = 1,
                   Email = "mauronoscue@gmail.com",
                   Password = "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG",
                   Active = false,
                   PersonId = 1,
                   RegistrationDate = new DateTime(2024, 7, 16),
                   CodePassword = "no hay",
                   RestrictionPoint= 3

               }, new User
               {

                   Id = 2,
                   Email = "andresmauricionoscue@gmail.com",
                   Password = "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG",
                   Active = false,
                   PersonId = 2,
                   RegistrationDate = new DateTime(2024, 7, 16),
                   CodePassword = "no hay",
                   RestrictionPoint = 3
               }, new User
               {

                   Id = 3,
                   Email = "doctor@gmail.com",
                   Password = "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG",
                   Active = false,
                   PersonId = 3,
                   RegistrationDate = new DateTime(2024, 7, 16),
                   CodePassword = "no hay",
                   RestrictionPoint = 3
               }
               , new User
               {

                   Id = 4,
                   Email = "User@gmail.com",
                   Password = "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG",
                   Active = false,
                   PersonId = 4,
                   RegistrationDate = new DateTime(2024, 7, 16),
                   CodePassword = "no hay",
                   RestrictionPoint = 3
               }
               );


            builder.ToTable("User", schema: "ModelSecurity");
            builder.HasOne(u => u.Person)
                .WithMany()
                .HasForeignKey(u => u.PersonId);

        }
    }
}
