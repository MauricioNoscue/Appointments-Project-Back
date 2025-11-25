using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back
{
    public class TypeCitationBusiness : BaseModelBusinessIm<TypeCitation, TypeCitationCreateDto, TypeCitationEditDto, TypeCitationListDto>, ITypeCitationBusiness
    {
        private readonly ITypeCitationData _data;

        public TypeCitationBusiness(IConfiguration configuration, ITypeCitationData data, ILogger<TypeCitationBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        public override async Task<IEnumerable<TypeCitationListDto>> GetAll()
        {
            try
            {
                var entities = await _data.GetAll();

                var result = entities.Select(tc => new TypeCitationListDto
                {
                    Id = tc.Id,
                    Name = tc.Name,
                    Description = tc.Description,
                    Icon = tc.Icon,
                    HasShedule = tc.Shedules != null && tc.Shedules.Any() // <-- aquí lo marcamos
                });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener lista de TypeCitation.");
                throw new BusinessException("Error inesperado al consultar los tipos de cita.", ex);
            }
        }
    }
}
