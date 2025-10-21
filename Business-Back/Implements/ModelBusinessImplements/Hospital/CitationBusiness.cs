using Business_Back.Implements.BaseModelBusiness;
using Data_Back;
using Entity_Back;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back
{
    public class CitationBusiness : BaseModelBusinessIm<Citation, CitationCreateDto, CitationEditDto, CitationListDto>, ICitationsBusiness
    {
        private readonly ICitationsData _data;

        public CitationBusiness(IConfiguration configuration, ICitationsData data, ILogger<CitationBusiness> logger)
            : base(configuration, data, logger) => _data = data;

        public Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate)
            => _data.GetUsedTimeBlocksByScheduleHourIdAndDateAsync(scheduleHourId, appointmentDate);

        public async Task<List<CitationListDto>> GetAllForListAsync(int UserId)
        {
            try
            {
                var Citations = await _data.GetAllForListAsync(UserId);
                return Citations.Adapt<List<CitationListDto>>();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetAllForListAsync");
                throw;
            }
        }


        public override async Task<bool> Update(CitationEditDto dto)
        {
            if (dto == null) throw new ValidationException(nameof(dto), "Datos inv�lidos");

            var entity = await _data.GetById(dto.Id);
            if (entity is null) throw new EntityNotFoundException($"Citation {dto.Id} no existe");

            // Merge solo de los campos presentes (gracias a IgnoreNullValues)
            dto.Adapt(entity);

            // Ahora entity mantiene ScheduleHourId/UserId/AppointmentDate/TimeBlock, etc.
            return await _data.Update(entity);
        }
    }

}

