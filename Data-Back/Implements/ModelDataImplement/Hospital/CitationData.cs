using Data_Back.Implements.BaseModelData;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    public class CitationsData : BaseModelData<Citation>, ICitationsData
    {
        public CitationsData(ApplicationDbContext context, ILogger<BaseModelData<Citation>> logger)
            : base(context, logger)
        {
        }
    }
}