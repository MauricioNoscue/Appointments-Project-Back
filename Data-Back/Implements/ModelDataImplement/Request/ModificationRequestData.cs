using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Request;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Request
{
    public class ModificationRequestData : BaseModelData<ModificationRequest>, IModificationRequestData
    {
        private readonly IConfiguration _configuration;
        public ModificationRequestData(ApplicationDbContext context, ILogger<ModificationRequestData> logger, IConfiguration configuration) : base(context, logger)
        {
            _configuration = configuration;
        }
    }
}
