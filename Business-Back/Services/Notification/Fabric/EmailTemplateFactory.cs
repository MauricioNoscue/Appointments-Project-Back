using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Models.SecurityModels;
using Utilities_Back.Helper;

namespace Business_Back.Services.Notification.Fabric
{
    public static class EmailTemplateFactory
    {
        public static (string subject, string body) BuildCitationCreated(User user, Entity_Back.Citation citation)
        {
            string subject = "Confirmación de tu cita médica";

            string body = SendCitation.SendCitaionTemaplate(new SendCitationDto
            {
                Email = user.Email,
                Date = citation.AppointmentDate,
                TimeBlock = citation.TimeBlock!.Value,
                UrlRedirect = "localhost:4200"
            });

            return (subject, body);
        }

        public static (string subject, string body) BuildCitationRescheduled(User user, Entity_Back.Citation newCitation)
        {
            string subject = "Tu cita ha sido reprogramada";

            string body = $"Hola {user.Email}, tu cita fue movida a {newCitation.AppointmentDate:yyyy-MM-dd} a las {newCitation.TimeBlock}.";

            return (subject, body);
        }

        public static (string subject, string body) BuildCitationCanceled(User user, Entity_Back.Citation citation)
        {
            string subject = "Tu cita ha sido cancelada";

            string body = $"Hola {user.Email}, tu cita programada para {citation.AppointmentDate:yyyy-MM-dd} fue cancelada.";

            return (subject, body);
        }
    }

}
