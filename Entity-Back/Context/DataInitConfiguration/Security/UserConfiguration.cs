//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entity_Back.Models.SecurityModels;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;

//namespace Entity_Back.Context.DataInitConfiguration.Security
//{
//    // rama mauro
//    internal class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        // rama mauro 
//        public void Configure(EntityTypeBuilder<User> builder)
//        {

//            builder.HasData(
//               new User
//               {
//                   Id = 1,
//                   Email = "mauronoscue@gmail.com",
//                   Password = "M1d!Citas2025",
//                   Active = false,
//                   PersonId = 1,
//                   RegistrationDate = new DateTime(2024, 7, 16)
//               }, new User
//               {

//                   Id = 2,
//                   Email = "isaTovarp.18@gmail.com",
//                   Password = "M2d!Citas2025",
//                   Active = false,
//                   PersonId = 2,
//                   RegistrationDate = new DateTime(2024, 7, 16)
//               }
//               );


//            builder.ToTable("User", schema: "ModelSecurity");
//            builder.HasOne(u => u.Person)
//                .WithMany()
//                .HasForeignKey(u => u.PersonId);

//        }
//    }
//}
