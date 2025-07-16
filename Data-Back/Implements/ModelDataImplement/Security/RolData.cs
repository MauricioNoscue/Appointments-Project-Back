using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Security
{
    public class RolData : BaseModelData<Rol>,IRolData
    {
        public RolData(ApplicationDbContext context,ILogger<RolData> logger) : base(context,logger)
        {
            
        }
    }
}
