using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Review;
using Entity_Back.Context;
using Entity_Back.Models.Review;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Review
{
    public class DoctorReviewData : BaseModelData<DoctorReview>, IDoctorReviewData
    {
        private readonly IConfiguration _configuration;

        public DoctorReviewData(
            ApplicationDbContext context,
            ILogger<DoctorReviewData> logger,
            IConfiguration configuration
        ) : base(context, logger)
        {
            _configuration = configuration;
        }
    }

}
