using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.IBusinessModel.Status;
using Data_Back.Interface.IDataModels.Security;
using Data_Back.Interface.IDataModels.Status;
using Entity_Back.Dto.Status.StatusTypesDto;
using Entity_Back.Models.Status;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Status
{
    public class StatusBusiness : BaseModelBusinessIm<StatusTypes, StatusTypeCreateDto, StatusTypeEditDto, StatusTypeListDto>,IStatusTypeBusiness
    {
        private readonly IStatusTypesData _data;

        public StatusBusiness(IConfiguration configuration, IStatusTypesData data, ILogger<StatusBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
    }


}

