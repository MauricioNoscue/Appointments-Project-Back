using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class ConsultingRoomData : BaseModelData<ConsultingRoom>, IConsultingRoomData
    {
        public ConsultingRoomData(ApplicationDbContext context, ILogger<BaseModelData<ConsultingRoom>> logger)
            : base(context, logger)
        {
        }
    }
}
