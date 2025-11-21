using Business_Back.Interface.IBusinessModel.Review;
using Entity_Back.Dto.ReviewDto.DoctorReviewDto;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Review
{
    public class DoctorReviewController
        : ControllerGeneric<DoctorReviewCreateDto, DoctorReviewEditDto, DoctorReviewListDto>
    {
        private readonly IDoctorReviewBusiness _service;

        public DoctorReviewController(
            IDoctorReviewBusiness service,
            ILogger<DoctorReviewController> logger
        ) : base(service, logger)
        {
            _service = service;
        }
    }
}
