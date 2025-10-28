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
    public class CityData : BaseModelData<City>, ICityData
    {
        public CityData(ApplicationDbContext context, ILogger<CityData> logger)
            : base(context, logger)
        {

        }
        public override async Task<IEnumerable<City>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<City>().Include(x => x.Departament)
                .Where(e => !e.IsDeleted)
                .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(City).Name}");
                throw;
            }
        }
    }
}

