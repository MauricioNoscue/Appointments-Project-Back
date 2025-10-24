using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Infrastructure;
using Data_Back.Interface.IDataModels.Infrastructure;
using Entity_Back.Dto.InfrastructureDto.Departament;
using Entity_Back.Dto.InfrastructureDto.DepartamentDto;
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
    public class DepartamentBusiness : BaseModelBusinessIm<Departament, DepartamentCreatedDto, DepartamentEditDto, DepartamentListDto>, IDepartamentBusiness
    {
        private readonly IDepartamentData _data;
        public DepartamentBusiness(IConfiguration configuration, IDepartamentData data, ILogger<DepartamentBusiness> logger)
           : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}

