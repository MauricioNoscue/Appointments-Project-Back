using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    public class SheduleBusiness : BaseModelBusinessIm<Shedule, SheduleCreateDto, SheduleEditDto, SheduleListDto>, ISheduleBusiness
    {
        private readonly ISheduleData _data;

        public SheduleBusiness(IConfiguration configuration, ISheduleData data, ILogger<SheduleBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        public async Task<SheduleListDto?> GetByIdTypeCitation(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El id debe ser mayor que cero.", nameof(id));
                }

                var shedule = await _data.GetByIdTypeCitation(id);
                return shedule.Adapt<SheduleListDto>();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener el horario por TypeCitationId {id}: {ex.Message}", ex);

            }
        }
    }
}
