using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    public class SheduleBusiness : BaseModelBusinessIm<Shedule, SheduleCreateDto, SheduleEditDto, SheduleListDto>, ISheduleBusiness
    {
        private readonly ISheduleData _data;

        public SheduleBusiness(IConfiguration configuration, ISheduleData data, ILogger<SheduleBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
