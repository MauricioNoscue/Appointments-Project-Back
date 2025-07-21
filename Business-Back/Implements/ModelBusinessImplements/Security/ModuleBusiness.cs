using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.ModuleDto;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class ModuleBusiness : BaseModelBusinessIm<Module, ModuleCreatedDto, ModuleEditDto, ModuleListDto>, IModuleBusiness
    {
        private readonly IModuleData _data;

        public ModuleBusiness(IConfiguration configuration, IModuleData data, ILogger<ModuleBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
