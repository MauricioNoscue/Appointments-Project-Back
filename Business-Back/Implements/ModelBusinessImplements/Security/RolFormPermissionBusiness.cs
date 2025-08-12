using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class RolFormPermissionBusiness : BaseModelBusinessIm<RolFormPermission, RolFormPermissionCreatedDto, RolFormPermissionEditDto, RolFormPermissionListDto>, IRolFormPermissionBusiness
    {
        private readonly IRolFormPermissionData _data;

        public RolFormPermissionBusiness(IConfiguration configuration, IRolFormPermissionData data, ILogger<RolFormPermissionBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }



        public async Task AssignPermissionsAsync(AssignPermissionsDto dto)
        {
            var existing = await _data.GetExistingFormPermissionsAsync(dto.RolId);

            var newAssignments = dto.Permissions
                .Where(p => !existing.Any(e => e.FormId == p.FormId && e.PermissionId == p.PermissionId))
                .Select(p => new RolFormPermission
                {
                    RolId = dto.RolId,
                    FormId = p.FormId,
                    PermissionId = p.PermissionId,
                    IsDeleted = false,
                    RegistrationDate = DateTime.UtcNow.AddHours(-5)
                })
            .ToList();

            if (newAssignments.Any())
                await _data.BulkInsertAsync(newAssignments);
        }

        public async Task UpdateRolFormPermissionsAsync(UpdateRolFormPermissionsDto dto)
        {
            var current = await _data.GetAllByRolIdAsync(dto.RolId);

            // 1. Desactivar los que no están en la nueva lista
            var toDelete = current
                .Where(existing =>
                    !dto.Permissions.Any(p => p.FormId == existing.FormId && p.PermissionId == existing.PermissionId) &&
                    !existing.IsDeleted)
                .ToList();

            foreach (var item in toDelete)
                item.IsDeleted = true;

            // 2. Determinar cuáles son nuevos (no existen en la BD como activos)
            var existingActive = current
                .Where(x => !x.IsDeleted)
                .Select(x => new { x.FormId, x.PermissionId })
                .ToList();

            var toAdd = dto.Permissions
                .Where(p => !existingActive.Any(e => e.FormId == p.FormId && e.PermissionId == p.PermissionId))
                .Select(p => new RolFormPermission
                {
                    RolId = dto.RolId,
                    FormId = p.FormId,
                    PermissionId = p.PermissionId,
                    IsDeleted = false,
                    RegistrationDate = DateTime.UtcNow.AddHours(-5)
                }).ToList();

            await _data.SaveChangesAsyncx(); // actualiza eliminaciones
            await _data.BulkInsertAsync(toAdd); // agrega nuevos
        }




    }

}
