using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.IDataModels.Menu;
using Entity_Back.Context;
using Entity_Back.Dto.SecurityDto.Menu;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;

namespace Data_Back.Implements.ModelDataImplement.Menu
{
    public class MenuRepository : IMenuRepository
    {

        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormVisibleDto>> GetVisibleFormsByRoleAsync(int roleId, CancellationToken ct)
        {
            int[] viewPerm = { 1, 2 }; 

            return await _context.Set<RolFormPermission>()
                .AsNoTracking()
                .Where(r => r.RolId == roleId && viewPerm.Contains(r.PermissionId))
                .Select(r => new FormVisibleDto
                {
                    FormId = r.Form.Id,
                    FormName = r.Form.Name,
                    Url = r.Form.Url,
                    FormIcon = r.Form.Icon,
                    ModuleId = r.Form.Module.Id,
                    ModuleName = r.Form.Module.Name,
                    ModuleIcon = r.Form.Module.Icon
                })
                .Distinct()
                .OrderBy(f => f.ModuleName).ThenBy(f => f.FormName)
                .ToListAsync(ct);
        }
    }
}
