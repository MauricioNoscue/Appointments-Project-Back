using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.Menu;

namespace Business_Back.Interface.IBusinessModel.Menu
{
    public interface IMenuBusiness
    {
        Task<List<MenuItemDto>> GetMenuByRoleAsync(int roleId, CancellationToken ct);
    }

}
