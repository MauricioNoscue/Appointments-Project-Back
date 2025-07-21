using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class RolUserBusiness : BaseModelBusinessIm<RolUser, RolUserCreatedDto, RolUserEditDto, RolUserList>
    {
        private readonly IRolUserData _data;
        public RolUserBusiness(IConfiguration configuration, IRolUserData data,ILogger<RolUserBusiness> logger): base(configuration,data,logger)
        {
            
        }
    }
}
