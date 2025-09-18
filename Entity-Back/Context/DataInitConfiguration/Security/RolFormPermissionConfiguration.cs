using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.SqlServer.Server;

namespace Entity_Back.Context.DataInitConfiguration.Security
{
    public class RolFormPermissionConfiguration : IEntityTypeConfiguration<RolFormPermission>
    {
        public void Configure(EntityTypeBuilder<RolFormPermission> builder)
        {
            var data = new List<RolFormPermission>();
            int id = 1;

            // Permisos comunes
            int[] permissionIds = { 1, 3, 4, 5 };

            // Formularios por rol
            int[] role4Forms = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            int[] role2Forms = { 18, 19, 20 };
            int[] role3Forms = { 21, 22, 23,24 };


            // Generar datos por rol
            data.AddRange(GenerateRolePermissions(id, 4, role4Forms, permissionIds, out id));
            data.AddRange(GenerateRolePermissions(id, 2, role2Forms, permissionIds, out id));
            data.AddRange(GenerateRolePermissions(id, 3, role3Forms, permissionIds, out id));


            builder.HasData(data);
        }

        /// <summary>
        /// Genera las combinaciones de permisos para un rol y lista de formularios
        /// </summary>
        private IEnumerable<RolFormPermission> GenerateRolePermissions(
             int startId,
             int roleId,
             int[] formIds,
             int[] permissionIds,
             out int nextId)
        {
            var result = new List<RolFormPermission>();
            int id = startId;

            foreach (var formId in formIds)
            {
                foreach (var permissionId in permissionIds)
                {
                    result.Add(new RolFormPermission
                    {
                        Id = id++,
                        RolId = roleId,
                        FormId = formId,
                        PermissionId = permissionId
                    });
                }
            }

            nextId = id;
            return result;
        }

    }

}
