using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.ReviewDto.DoctorReviewDto
{
    public class DoctorReviewEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }
        public int? CitationId { get; set; }

        public string? Comment { get; set; }
    }

}
