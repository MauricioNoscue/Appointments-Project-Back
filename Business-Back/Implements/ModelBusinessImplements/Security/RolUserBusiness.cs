using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class RolUserBusiness : BaseModelBusinessIm<RolUser, RolUserCreatedDto, RolUserEditDto, RolUserList>,IRolUserBusiness
    {
        private readonly IRolUserData _data;
        public RolUserBusiness(IConfiguration configuration, IRolUserData data,ILogger<RolUserBusiness> logger): base(configuration,data,logger)
        {
            _data = data;
        }
        public async Task UpdateUserRolesAsync(UpdateUserRolesDto dto)
        {
            var current = await _data.GetAllByUserIdAsync(dto.UserId);

            var toDelete = current
                .Where(r => !dto.RolIds.Contains(r.RolId) && !r.IsDeleted)
                .ToList();

            var existingActiveRolIds = current
                .Where(r => !r.IsDeleted)
                .Select(r => r.RolId)
                .ToList();

            var toAdd = dto.RolIds
                .Where(rid => !existingActiveRolIds.Contains(rid))
                .Select(rid => new RolUser
                {
                    UserId = dto.UserId,
                    RolId = rid,
                    IsDeleted = false,
                    RegistrationDate = DateTime.UtcNow.AddHours(-5)
                }).ToList();

            // Desactivamos los que ya no están
            foreach (var item in toDelete)
                item.IsDeleted = true;

            await _data.SaveChangesAsyncc(); // guarda los cambios de eliminados
            await _data.BulkInsertAsync(toAdd); // agrega los nuevos
        }






        public async Task<IEnumerable<object>> GetRolesAndPermissionsByUserIdAsync(int userId)
        {
            var roles = await _data.GetRolesAndPermissionsByUserIdAsync(userId);

            var result = roles.Select(r => new {
                Rol = r.Rol.Name,
                Permisos = r.Rol.RolFormPermission.Select(p => new {
                    Form = p.Form.Name,
                    Permiso = p.Permission.Name
                }).ToList()
            });

            return result;
        }



        public async Task AssignRolesAsync(AssignRolesDto dto)
        {
            var existingRolIds = await _data.GetExistingRolIdsForUser(dto.UserId);

            var newRolUsers = dto.RolIds
                .Where(rolId => !existingRolIds.Contains(rolId))
                .Select(rolId => new RolUser
                {
                    UserId = dto.UserId,
                    RolId = rolId,
                    IsDeleted = false,
                    RegistrationDate = DateTime.UtcNow.AddHours(-5)
                }).ToList();

            if (newRolUsers.Any())
                await _data.BulkInsertAsync(newRolUsers);
        }

    }
}
