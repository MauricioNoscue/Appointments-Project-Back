using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Medical
{
    public class ScheduleHourController : ControllerGeneric<ScheduleHourCreateDto, ScheduleHourEditDto, ScheduleHourListDto>
    {
        public ScheduleHourController(
            IBaseModelBusiness<ScheduleHourCreateDto, ScheduleHourEditDto, ScheduleHourListDto> service,
            ILogger<ScheduleHourController> logger)
            : base(service, logger)
        {
        }
    }
}
