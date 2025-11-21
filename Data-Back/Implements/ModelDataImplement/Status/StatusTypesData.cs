using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Security;
using Data_Back.Interface.IDataModels.Status;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Entity_Back.Models.Status;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Status
{
    public class StatusTypesData : BaseModelData<StatusTypes>, IStatusTypesData
    {
        private readonly IConfiguration _configuration;

        public StatusTypesData(ApplicationDbContext context, ILogger<StatusTypesData> logger, IConfiguration configuration) : base(context, logger)
        {
            _configuration = configuration;
        }

    }
}
