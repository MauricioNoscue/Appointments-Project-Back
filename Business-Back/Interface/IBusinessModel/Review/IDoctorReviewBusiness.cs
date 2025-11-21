using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Dto.ReviewDto.DoctorReviewDto;

namespace Business_Back.Interface.IBusinessModel.Review
{
    public interface IDoctorReviewBusiness
      : IBaseModelBusiness<DoctorReviewCreateDto, DoctorReviewEditDto, DoctorReviewListDto>
    {
    }

}
