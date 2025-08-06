using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Security
{
    public class PersonData : BaseModelData<Person>,IpersonData
    {
        public PersonData(ApplicationDbContext context, ILogger<PersonData> logger) : base(context, logger)
        {

        }
    }
}
