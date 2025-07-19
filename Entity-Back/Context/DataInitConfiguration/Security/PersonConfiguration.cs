//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entity_Back.Models.SecurityModels;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using Entity_Back.Enum;

//namespace Entity_Back.Context.DataInitConfiguration.Security
//{
//    public class PersonConfiguration : IEntityTypeConfiguration<Person>
//    {
//        public void Configure(EntityTypeBuilder<Person> builder)
//        {

//            builder.Property(p => p.Gender)
//       .HasConversion<string>();

//            builder.Property(p => p.HealthRegime)
//                   .HasConversion<string>();


//            builder.ToTable("Person", schema: "ModelSecurity", t =>
//            {
//                t.HasCheckConstraint("CK_Person_Gender", "[Gender] IN ('Masculino', 'Femenino')");
//                t.HasCheckConstraint("CK_Person_HealthRegime", "[HealthRegime] IN ('Contributivo', 'Subsidiado', 'Excepcion')");
//            });


//            builder.HasOne(p => p.DocumentType)
//                   .WithMany(e => e.Person)
//                   .HasForeignKey(p => p.DocumentTypeId);


//            builder.HasOne(p => p.Eps)
//               .WithMany(e => e.Person)
//               .HasForeignKey(p => p.EpsId);


//                    builder.HasData(
//                        new Person
//                        {
//                            Id = 1,
//                            FullName = "Mauricio",
//                            FullLastName = "Noscue",
//                            DocumentTypeId = 1, 
//                            Document = "1084922863",
//                            DateBorn = new DateTime(2006, 6, 13),
//                            PhoneNumber = "3133156032",
//                            EpsId = 1,
//                            Gender = Gender.Masculino,
//                            HealthRegime = HealthRegime.Contributivo,
//                            RegistrationDate = new DateTime(2024, 7, 16)

//                        },
//                        new Person
//                        {
//                            Id =2,
//                            FullName = "María isabel",
//                            FullLastName = "Noscue",
//                            DocumentTypeId = 1,
//                            Document = "1084922863",
//                            DateBorn = new DateTime(2006, 6, 13),
//                            PhoneNumber = "3133156032",
//                            EpsId = 1,
//                            Gender = Gender.Femenino,
//                            HealthRegime = HealthRegime.Contributivo,
//                            RegistrationDate = new DateTime(2024, 7, 16)
//                        }
            
            
            
//            );

           


//        }
//    }
//}
