using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Infrastructure;
using Data_Back.Interface.IDataModels.Infrastructure;
using Entity_Back.Dto.InfrastructureDto.InstitutionDto;
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
    public class InstitutionBusiness : BaseModelBusinessIm<Institution, InstitutionCreatedDto, InstitutionEditDto, InstitutionListDto>, IInstitutionBusiness
    {
        private readonly IInstitutionData _data;
        public InstitutionBusiness(IConfiguration configuration, IInstitutionData data, ILogger<InstitutionBusiness> logger)
           : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}

