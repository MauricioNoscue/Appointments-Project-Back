using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class TypeCitationData : BaseModelData<TypeCitation>, ITypeCitationData
    {
        public TypeCitationData(ApplicationDbContext context, ILogger<BaseModelData<TypeCitation>> logger)
            : base(context, logger)
        {
        }

        public override async Task<IEnumerable<TypeCitation>> GetAll()
        {
            try
            {
                var query = await _context.TypeCitations
                    .Where(x => !x.IsDeleted)
                    .Select(tc => new TypeCitation
                    {
                        Id = tc.Id,
                        Name = tc.Name,
                        Description = tc.Description,
                        Icon = tc.Icon,
                        // solo necesitamos saber si existen schedules
                        Shedules = tc.Shedules
                            .Where(s => !s.IsDeleted)
                            .Select(s => new Shedule { Id = s.Id })
                            .ToList()
                    })
                    .ToListAsync();

                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener TypeCitation con información mínima.");
                throw;
            }
        }
    }
}
