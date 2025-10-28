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
    public class DepartamentData : BaseModelData<Departament>, IDepartamentData
    {
        public DepartamentData(ApplicationDbContext context, ILogger<DepartamentData> logger)
            : base(context, logger)
        {

        }
    }
}
