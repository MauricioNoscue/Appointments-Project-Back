using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class PersonBusiness :BaseModelBusinessIm<Person,PersonCreatedDto,PersonEditDto,PersonListDto>,IPersonBusiness
    {

        private readonly IpersonData _data;

        public PersonBusiness(IConfiguration configuration, IpersonData data, ILogger<PersonBusiness> logger) :
            base(configuration, data, logger)
        {
            _data = data;
        }

    }
}
