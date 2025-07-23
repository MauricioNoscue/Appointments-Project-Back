using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    public class ConsultingRoomBusiness : BaseModelBusinessIm<ConsultingRoom, ConsultingRoomCreateDto, ConsultingRoomEditDto, ConsultingRoomListDto>, IConsultingRoomBusiness
    {
        private readonly IConsultingRoomData _data;

        public ConsultingRoomBusiness(IConfiguration configuration, IConsultingRoomData data, ILogger<ConsultingRoomBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
