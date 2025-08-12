using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models.SecurityModels;

namespace Data_Back.Interface.IDataModels.Security
{
    public interface IRolFormPermissionData : IBaseModelData<RolFormPermission>
    {
        public  Task<List<(int FormId, int PermissionId)>> GetExistingFormPermissionsAsync(int rolId);
        public Task BulkInsertAsync(List<RolFormPermission> entities);
        public  Task<List<RolFormPermission>> GetAllByRolIdAsync(int rolId);
        public Task SaveChangesAsyncx();
    }
}
