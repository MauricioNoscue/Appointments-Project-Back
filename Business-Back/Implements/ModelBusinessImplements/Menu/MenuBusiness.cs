using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel.Menu;
using Data_Back.Interface.IDataModels.Menu;
using Entity_Back.Dto.SecurityDto.Menu;

namespace Business_Back.Implements.ModelBusinessImplements.Menu
{
    public class MenuBusiness : IMenuBusiness
    {

        private readonly IMenuRepository _data;

        public MenuBusiness(IMenuRepository data)
        {
            _data = data;
        }
        public async Task<List<MenuItemDto>> GetMenuByRoleAsync(int roleId, CancellationToken ct)
        {
            var forms = await _data.GetVisibleFormsByRoleAsync(roleId, ct);

            // Agrupar por módulo
            var modules = forms
                .GroupBy(f => new { f.ModuleId, f.ModuleName, f.ModuleIcon })
                .OrderBy(g => g.Key.ModuleName);

            var group = new MenuItemDto
            {
                Id = "group-modulos",
                Title = "Módulos",
                Type = "group",
                Children = new List<MenuItemDto>()
            };

            foreach (var mod in modules)
            {
                var collapse = new MenuItemDto
                {
                    Id = $"module-{mod.Key.ModuleId}",
                    Title = mod.Key.ModuleName,
                    Type = "collapse",
                    Icon = mod.Key.ModuleIcon ?? "apps",
                    Children = mod.Select(f => new MenuItemDto
                    {
                        Id = $"form-{f.FormId}",
                        Title = f.FormName,
                        Type = "item",
                        Url = f.Url,
                        Icon = f.FormIcon ?? "menu"
                    }).ToList()
                };

                group.Children.Add(collapse);
            }

            return new List<MenuItemDto> { group };
        }
    }
}
