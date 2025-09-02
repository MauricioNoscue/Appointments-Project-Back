using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class SheduleData : BaseModelData<Shedule>, ISheduleData
    {
        private readonly ApplicationDbContext _context; 
        public SheduleData(ApplicationDbContext context, ILogger<BaseModelData<Shedule>> logger)
            : base(context, logger)
        {
            _context = context;
        }





        public override async Task<IEnumerable<Shedule>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<Shedule>()
                    .Include(e => e.Doctor)
                    .Include(t => t.TypeCitation)
                    .Include(c => c.ConsultingRoom)
                .Where(e => !e.IsDeleted)
                .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Shedule).Name}");
                throw;
            }
        }



        public async Task<Shedule?>  GetByIdTypeCitation(int id)
        {
            try
            {
                var shedule = await _context.Set<Shedule>()
                    .Where(s => s.TypeCitationId == id && !s.IsDeleted)
                    .FirstOrDefaultAsync();
                return shedule;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener el horario por TypeCitationId {id}: {ex.Message}", ex);
            }
        }

    }
}
