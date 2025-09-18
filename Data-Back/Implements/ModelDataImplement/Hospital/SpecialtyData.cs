using Data_Back.Implements.BaseModelData;
using Entity_Back.Context;
using Entity_Back.Models.HospitalModel;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    public class SpecialtyData : BaseModelData<Specialty>, ISpecialtyData
    {
        public SpecialtyData(ApplicationDbContext context, ILogger<BaseModelData<Specialty>> logger)
            : base(context, logger)
        {
        }
    }
}