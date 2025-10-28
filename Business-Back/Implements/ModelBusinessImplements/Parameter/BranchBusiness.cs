using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.IBusinessModel.Infrastructure;
using Data_Back.Interface.IDataModels.Infrastructure;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.InfrastructureDto.BranchDto;
using Entity_Back.Models.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Implements.ModelBusinessImplements.Infrastructure
{
    public class BranchBusiness : BaseModelBusinessIm<Branch, BranchCreatedDto, BranchEditDto, BranchListDto>, IBranchBusiness
    {
        private readonly IBranchData _data;
        public BranchBusiness(IConfiguration configuration, IBranchData data, ILogger<BranchBusiness> logger)
           : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
