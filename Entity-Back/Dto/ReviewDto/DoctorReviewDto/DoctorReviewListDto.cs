using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Entity_Back.Dto.ReviewDto.DoctorReviewDto
{
    public class DoctorReviewListDto : BaseModel
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; }

        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int? CitationId { get; set; }

        public string DoctorName { get; set; }
        public string UserName { get; set; }
    }

}
