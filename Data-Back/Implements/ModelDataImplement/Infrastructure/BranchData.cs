using Data_Back.Implements.BaseModelData;
using Data_Back.Implements.ModelDataImplement.Security;
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
    public class BranchData : BaseModelData<Branch>,IBranchData
    {
        public BranchData(ApplicationDbContext context, ILogger<BranchData> logger)
            : base(context, logger)
        {

        }
    }
}
