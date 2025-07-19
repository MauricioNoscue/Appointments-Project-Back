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
    public class UserData : BaseModelData<User>, IUserData
    {
        public UserData(ApplicationDbContext context, ILogger<UserData> logger) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<User>()
                .Where(e => !e.IsDeleted)
                  .Include(u => u.Person)
                .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(User).Name}");
                throw;
            }
        }


        public async Task<User> Save(User entity)
        {
            try
            {
                // Si tiene Person, asegurarse de que se guarde correctamente
                if (entity.Person != null)
                {
                    entity.Person.Active = true;
                    entity.Person.IsDeleted = false;
                }

                await _context.Set<User>().AddAsync(entity);
                await _context.SaveChangesAsync();

            
                var savedEntity = await _context.Set<User>()
                    .Include(u => u.Person)
                        .ThenInclude(p => p.DocumentType)
                    .Include(u => u.Person)
                        .ThenInclude(p => p.Eps)
                    .FirstOrDefaultAsync(u => u.Id == entity.Id);

                return savedEntity ?? entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear el registro para la entidad: {typeof(User).Name}");
                throw;
            }
        }


    }
}
