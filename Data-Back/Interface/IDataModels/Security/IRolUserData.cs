using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models.SecurityModels;

namespace Data_Back.Interface.IDataModels.Security
{
    public interface IRolUserData : IBaseModelData<RolUser>
    {
        public Task<List<RolUser>> GetRolesAndPermissionsByUserIdAsync(int userId);
        public Task<List<int>> GetExistingRolIdsForUser(int userId);
        public Task BulkInsertAsync(List<RolUser> rolUsers);
        public Task<List<RolUser>> GetAllByUserIdAsync(int userId);
        public Task SaveChangesAsyncc();
    }
}
