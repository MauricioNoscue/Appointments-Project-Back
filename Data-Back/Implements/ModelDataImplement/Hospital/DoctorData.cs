using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class DoctorData : BaseModelData<Doctor>, IDoctorData
    {
        public DoctorData(ApplicationDbContext context, ILogger<BaseModelData<Doctor>> logger)
            : base(context, logger)
        {
        }

    }
}
