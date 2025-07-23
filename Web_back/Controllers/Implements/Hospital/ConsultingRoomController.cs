using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class ConsultingRoomController : ControllerGeneric<ConsultingRoomCreateDto, ConsultingRoomEditDto, ConsultingRoomListDto>
    {
        public ConsultingRoomController(
            IBaseModelBusiness<ConsultingRoomCreateDto, ConsultingRoomEditDto, ConsultingRoomListDto> service,
            ILogger<ConsultingRoomController> logger)
            : base(service, logger)
        {
        }
    }
}
