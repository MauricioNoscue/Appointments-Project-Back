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
