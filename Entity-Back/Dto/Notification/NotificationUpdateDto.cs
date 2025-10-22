using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Entity_Back.Dto.Notification
{
    public class NotificationEditDto
    {

        public int Id { get; set; }
        [Required, StringLength(2000)]
        public string Title { get; set; }
        public int? CitationId { get; set; }

        [Required, StringLength(2000)]
        public string Message { get; set; }
        [Required]
        public StatusNotification StateNotification { get; set; }
        [Required]

        public TypeNotification TypeNotification { get; set; }
        public string? RedirectUrl { get; set; }
    }
}
