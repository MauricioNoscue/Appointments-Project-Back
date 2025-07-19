using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class RolBusiness : BaseModelBusinessIm<Rol,RolCreatedDto,RolEditDto,RolListDto>,IRolBusiness
    {
        private readonly IRolData _data;

        public RolBusiness(IConfiguration configuration,IRolData data,ILogger<RolBusiness> logger):
            base(configuration,data,logger)
        {
            
        }
    }
}
