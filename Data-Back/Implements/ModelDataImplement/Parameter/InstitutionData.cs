using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Infrastructure;
using Entity_Back.Context;
using Entity_Back.Models.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Back.Implements.ModelDataImplement.Infrastructure
{
    public class InstitutionData : BaseModelData<Institution>, IInstitutionData
    {
        public InstitutionData(ApplicationDbContext context, ILogger<InstitutionData> logger)
            : base(context, logger)
        {

        }
        public override async Task<IEnumerable<Institution>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<Institution>().Include(x => x.City)
                .Where(e => !e.IsDeleted)
                .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Institution).Name}");
                throw;
            }
        }
    }
}