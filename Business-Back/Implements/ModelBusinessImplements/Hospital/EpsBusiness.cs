using Business_Back.Implements.BaseModelBusiness;
using Data_Back;
using Entity_Back;
using Entity_Back.Models.HospitalModel;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back
{
    public class EpsBusiness : BaseModelBusinessIm<Eps, EpsCreatedDto, EpsEditDto, EpsListDto>
    {
        private readonly IEpsData _data;

        public EpsBusiness(IConfiguration configuration, IEpsData data, ILogger<EpsBusiness> logger)
            : base(configuration, data, logger) => _data = data;

        public override async Task<bool> Update(EpsEditDto dto)
        {
            if (dto == null) throw new ValidationException(nameof(dto), "Datos inválidos");

            var entity = await _data.GetById(dto.Id);
            if (entity is null) throw new EntityNotFoundException($"Eps {dto.Id} no existe");

            dto.Adapt(entity);

            return await _data.Update(entity);
        }
    }
}