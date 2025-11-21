using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Review;
using Data_Back.Interface.IDataModels.Review;
using Entity_Back.Dto.ReviewDto.DoctorReviewDto;
using Entity_Back.Models.Review;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Review
{
    public class DoctorReviewBusiness
      : BaseModelBusinessIm<DoctorReview, DoctorReviewCreateDto, DoctorReviewEditDto, DoctorReviewListDto>,
        IDoctorReviewBusiness
    {
        private readonly IDoctorReviewData _data;

        public DoctorReviewBusiness(
            IConfiguration configuration,
            IDoctorReviewData data,
            ILogger<DoctorReviewBusiness> logger
        ) : base(configuration, data, logger)
        {
            _data = data;
        }
    }

}
