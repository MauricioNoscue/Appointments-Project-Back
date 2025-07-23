using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class SheduleData : BaseModelData<Shedule>, ISheduleData
    {
        public SheduleData(ApplicationDbContext context, ILogger<BaseModelData<Shedule>> logger)
            : base(context, logger)
        {
            
        }
    }
}
