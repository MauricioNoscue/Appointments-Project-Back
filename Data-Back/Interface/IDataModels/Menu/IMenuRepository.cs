using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.Menu;

namespace Data_Back.Interface.IDataModels.Menu
{
    public interface IMenuRepository
    {
        Task<List<FormVisibleDto>> GetVisibleFormsByRoleAsync(int roleId, CancellationToken ct);
    }

}
