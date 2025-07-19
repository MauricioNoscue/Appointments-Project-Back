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
    public class RolUserConfiguration : IEntityTypeConfiguration<RolUser>
    {
        public void Configure(EntityTypeBuilder<RolUser> builder)
        {
            builder.HasData(

                 new RolUser { Id = 1, RolId = 1, UserId = 1,
                     RegistrationDate = new DateTime(2024, 7, 16)  },
                 new RolUser { Id = 2, RolId = 2, UserId = 2,
                     RegistrationDate = new DateTime(2024, 7, 16) }

               );
            builder.ToTable("RolUser", schema: "ModelSecurity");
            builder.HasOne(e => e.Rol)
                   .WithMany(c => c.RolUser)
                   .HasForeignKey(e => e.RolId);

            builder.HasOne(e => e.User)
               .WithMany(c => c.RolUser)
               .HasForeignKey(e => e.UserId);

        }
    }
}
