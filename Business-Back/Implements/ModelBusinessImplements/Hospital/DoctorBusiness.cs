using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    public class DoctorBusiness : BaseModelBusinessIm<Doctor, DoctorCreateDto, DoctorEditDto, DoctorListDto>, IDoctorBusiness
    {
        private readonly IDoctorData _data;

        public DoctorBusiness(IConfiguration configuration, IDoctorData data, ILogger<DoctorBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
