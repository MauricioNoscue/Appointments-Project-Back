using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Notification
{
    public class NotificationEditDto
    {
        // PATCH parcial: TODO es opcional. Solo se actualiza lo que venga con valor.
        public int Id { get; set; }
        public int? CitationId { get; set; }

        [StringLength(2000)]
        public string? Message { get; set; }

   
        public bool? StateNotification { get; set; }   // "UNREAD" | "READ"

        [StringLength(20)]
        public string? TypeNotification { get; set; }    // "INFO" | "WARNING" | "ALERT" | "SYSTEM"
    }
}
