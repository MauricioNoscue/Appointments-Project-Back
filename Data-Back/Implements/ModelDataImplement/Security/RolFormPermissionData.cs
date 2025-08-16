using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Security
{
    public class RolFormPermissionData : BaseModelData<RolFormPermission>, IRolFormPermissionData
    {
        public RolFormPermissionData(ApplicationDbContext context, ILogger<RolFormPermissionData> logger)
            : base(context, logger)
        {

        }

        // Trae todos los form-permiso asignados actualmente al rol (no eliminados)
        public async Task<List<(int FormId, int PermissionId)>> GetExistingFormPermissionsAsync(int rolId)
        {
            var result = await _context.Set<RolFormPermission>()
                .Where(x => x.RolId == rolId && !x.IsDeleted)
                .Select(x => new { x.FormId, x.PermissionId })
                .ToListAsync();

            // Convertir la lista anónima a lista de tuplas
            return result.Select(x => (x.FormId, x.PermissionId)).ToList();
        }


        // Inserta múltiples registros nuevos
        public async Task BulkInsertAsync(List<RolFormPermission> entities)
        {
            _context.RolFormPermission.AddRange(entities);
            await _context.SaveChangesAsync();
        }


        public async Task<List<RolFormPermission>> GetAllByRolIdAsync(int rolId)
        {
            return await _context.RolFormPermission
                .Where(x => x.RolId == rolId && !x.IsDeleted) // Solo activos
                .ToListAsync();
        }

        public async Task SaveChangesAsyncx()
        {
            await _context.SaveChangesAsync();
        }


    }
}
