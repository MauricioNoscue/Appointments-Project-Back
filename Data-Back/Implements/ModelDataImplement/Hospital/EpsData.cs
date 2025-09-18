using Data_Back.Implements.BaseModelData;
using Entity_Back.Context;
using Entity_Back.Models.HospitalModel;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    public class EpsData : BaseModelData<Eps>, IEpsData
    {
        public EpsData(ApplicationDbContext context, ILogger<BaseModelData<Eps>> logger)
            : base(context, logger)
        {
        }
    }
}