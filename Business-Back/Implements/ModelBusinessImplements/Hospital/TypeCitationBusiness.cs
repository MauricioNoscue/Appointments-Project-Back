using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
    }
}
