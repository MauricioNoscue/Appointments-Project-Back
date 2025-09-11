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
    public class RolFormPermissionConfiguration : IEntityTypeConfiguration<RolFormPermission>
    {
        public void Configure(EntityTypeBuilder<RolFormPermission> builder)
        {
            //builder.ToTable("RolFormPermission", schema: "ModelSecurity");

            var data = new List<RolFormPermission>();
            int id = 1;

            // Forms disponibles (1 → 17)
            int[] formIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            int[] permissionIds = { 1, 3, 4, 5 };

            foreach (var formId in formIds)
            {
                foreach (var permissionId in permissionIds)
                {
                    data.Add(new RolFormPermission
                    {
                        Id = id++,
                        RolId = 4,
                        FormId = formId,
                        PermissionId = permissionId
                    });
                }
            }

            builder.HasData(data);
        }
    }
}
