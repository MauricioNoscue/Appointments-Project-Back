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
    public class RolUserData : BaseModelData<RolUser>,IRolUserData
    {
        public RolUserData(ApplicationDbContext context, ILogger<RolUserData> logger) : base(context,logger)
        {
            
        }



        public override async Task<IEnumerable<RolUser>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<RolUser>()
                .Where(e => !e.IsDeleted)
                  .Include(u => u.Rol)
                  .Include(u => u.User)

                .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(RolUser).Name}");
                throw;
            }
        }

    }
}
