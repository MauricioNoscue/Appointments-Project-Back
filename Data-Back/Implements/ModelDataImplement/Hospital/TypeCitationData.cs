using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class TypeCitationData : BaseModelData<TypeCitation>, ITypeCitationData
    {
        public TypeCitationData(ApplicationDbContext context, ILogger<BaseModelData<TypeCitation>> logger)
            : base(context, logger)
        {
        }
    }
}
