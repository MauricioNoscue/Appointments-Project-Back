using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Notification.SendEmail
{
    public class SendCitationDto
    {
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeBlock { get; set; }

        public string? UrlRedirect { get; set; }


    }
}
