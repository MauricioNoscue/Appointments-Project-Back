using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Request;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Request
{
    public class ModificationRequestData : BaseModelData<ModificationRequest>, IModificationRequestData
    {
        private readonly IConfiguration _configuration;
        public ModificationRequestData(ApplicationDbContext context, ILogger<ModificationRequestData> logger, IConfiguration configuration) : base(context, logger)
        {
            _configuration = configuration;
        }



        public override async Task<IEnumerable<ModificationRequest>> GetAll()
        {
            try
            {
                var list = await _context.Set<ModificationRequest>()
                    .AsNoTracking()
                    .Where(e => !e.IsDeleted)
                    .Include(e => e.Statustypes)                     
                    .Include(e => e.User)                               // ✔ necesario
                        .ThenInclude(u => u.Person)                     // ✔ necesario
                            .ThenInclude(p => p.DocumentType)           // ✔ necesario
                    .ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de {nameof(ModificationRequest)}");
                throw;
            }
        }

        public override async Task<IEnumerable<ModificationRequest>> GetAllUser(int userId)
        {
            try
            {
                var ltsModel = await _context.Set<ModificationRequest>()
                          .AsNoTracking()
                    .Where(e => !e.IsDeleted)
                    .Include(e => e.Statustypes)
                    .Include(e => e.User)                               // ✔ necesario
                        .ThenInclude(u => u.Person)                     // ✔ necesario
                            .ThenInclude(p => p.DocumentType)           // ✔ necesario
                .Where(e => !e.IsDeleted && EF.Property<int>(e, "UserId") == userId)
                .ToListAsync();
                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(ModificationRequest).Name} para el usuario con ID: {userId}");
                throw;
            }
        }


        public override async Task<ModificationRequest?> GetById(int id)
        {
            try
            {
                var entity = await _context.Set<ModificationRequest>()
                    .AsNoTracking()
                    .Where(e => !e.IsDeleted && e.Id == id)
                    .Include(e => e.Statustypes)
                    .Include(e => e.User)
                        .ThenInclude(u => u.Person)
                            .ThenInclude(p => p.DocumentType)
                    .FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el registro {nameof(ModificationRequest)} con ID: {id}");
                throw;
            }
        }


    }
}
