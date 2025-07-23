using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Infrastructure;
using Entity_Back.Context;
using Entity_Back.Models.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Back.Implements.ModelDataImplement.Infrastructure
{
    public class InstitutionData : BaseModelData<Institution>, IInstitutionData
    {
        public InstitutionData(ApplicationDbContext context, ILogger<InstitutionData> logger)
            : base(context, logger)
        {

        }
    }
}