using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Notification
{
    public class NotificationCreateDto
    {
        [Required]
        public int CitationId { get; set; }

        [Required, StringLength(2000)]
        public string Message { get; set; } = null!;

       
        public bool? StateNotification { get; set; }  

        //[StringLength(20)]
        public string? TypeNotification { get; set; }   // "INFO" | "WARNING" | "ALERT" | "SYSTEM" (opcional)
    }
}
