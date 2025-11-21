using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.IBusinessModel.Request;
using Data_Back.Interface.IDataModels.Request;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.RequestDto;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Request
{
    public class ModificationRequestBusiness : BaseModelBusinessIm<   ModificationRequest,ModificationRequestCreateDto, ModificationRequestEditDto, ModificationRequestListDto>, IModificationRequestBusiness
    {
        private readonly IModificationRequestData _data;

        public ModificationRequestBusiness(IConfiguration configuration, IModificationRequestData data, ILogger<ModificationRequestBusiness> logger)
       : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
