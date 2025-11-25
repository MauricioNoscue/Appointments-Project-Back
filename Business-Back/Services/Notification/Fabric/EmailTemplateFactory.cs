using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Enum;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;
using Utilities_Back.Helper;

namespace Business_Back.Services.Notification.Fabric
{
    /// <summary>
    /// Fábrica para la generación de plantillas de correo electrónico para notificaciones de citas y solicitudes.
    /// </summary>
    public static class EmailTemplateFactory
    {
        /// <summary>
        /// Construye el asunto y cuerpo del correo para la confirmación de una cita médica creada.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="citation">Cita médica creada.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildCitationCreated(User user, Entity_Back.Citation citation)
        {
            try
            {
                string subject = "Confirmación de tu cita médica";

                string body = SendCitation.BuildCitationTemplate(
                    CitationEmailType.Created,
                    new SendCitationDto
                    {
                        Email = user.Email,
                        Date = citation.AppointmentDate,
                        TimeBlock = citation.TimeBlock!.Value,
                        UrlRedirect = "localhost:4200"
                    }
                );

                return (subject, body);
            }
            catch (Exception ex)
            {
                // Manejo de excepción (puede ser log o rethrow según la política del proyecto)
                throw;
            }
        }

        /// <summary>
        /// Construye el asunto y cuerpo del correo para una cita reprogramada.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="citation">Cita médica reprogramada.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildCitationRescheduled(User user, Entity_Back.Citation citation)
        {
            try
            {
                string subject = "Tu cita ha sido reprogramada";

                string body = SendCitation.BuildCitationTemplate(
                    CitationEmailType.Rescheduled,
                    new SendCitationDto
                    {
                        Email = user.Email,
                        Date = citation.AppointmentDate,
                        TimeBlock = citation.TimeBlock!.Value,
                        UrlRedirect = "localhost:4200"
                    }
                );

                return (subject, body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Construye el asunto y cuerpo del correo para una cita cancelada.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="citation">Cita médica cancelada.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildCitationCanceled(User user, Entity_Back.Citation citation)
        {
            try
            {
                string subject = "Tu cita ha sido cancelada";

                string body = SendCitation.BuildCitationTemplate(
                    CitationEmailType.Canceled,
                    new SendCitationDto
                    {
                        Email = user.Email,
                        Date = citation.AppointmentDate,
                        TimeBlock = citation.TimeBlock!.Value,
                        UrlRedirect = "localhost:4200"
                    }
                );

                return (subject, body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Construye el asunto y cuerpo del correo para una solicitud aprobada.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="request">Solicitud aprobada.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildApproved(User user, ModificationRequest request)
        {
            try
            {
                string subject = "Tu solicitud ha sido aprobada";

                string body = SendCitation.BuildRequestTemplate(
                    RequestEmailType.Approved,
                    request,
                    user.Email,
                    "https://localhost:4200/solicitudes/detalle/" + request.Id
                );

                return (subject, body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Construye el asunto y cuerpo del correo para una solicitud rechazada.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="request">Solicitud rechazada.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildRejected(User user, ModificationRequest request)
        {
            try
            {
                string subject = "Tu solicitud ha sido rechazada";

                string body = SendCitation.BuildRequestTemplate(
                    RequestEmailType.Rejected,
                    request,
                    user.Email,
                    "https://localhost:4200/solicitudes/detalle/" + request.Id
                );

                return (subject, body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Construye el asunto y cuerpo del correo para una cita marcada como no asistida.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="citation">Cita médica no asistida.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildCitationMissed(User user, Entity_Back.Citation citation)
        {
            try
            {
                string subject = "Tu cita fue marcada como no asistida";

                string body = SendCitation.BuildCitationStatusTemplate(user, citation);

                return (subject, body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Construye el asunto y cuerpo del correo para una cita completada correctamente.
        /// </summary>
        /// <param name="user">Usuario destinatario.</param>
        /// <param name="citation">Cita médica completada.</param>
        /// <returns>Tupla con asunto y cuerpo del correo.</returns>
        public static (string subject, string body) BuildCitationCompleted(User user, Entity_Back.Citation citation)
        {
            try
            {
                string subject = "Tu cita fue atendida correctamente";

                string body = SendCitation.BuildCitationStatusTemplate(user, citation);

                return (subject, body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static (string subject, string body) BuildTwoFactorCode(User user, string code)
        {
            try
            {
                string subject = "Código de verificación (2FA)";
                string body = SendCitation.BuildTwoFactorCodeTemplate(user, code);

                return (subject, body);
            }
            catch
            {
                throw;
            }
        }

    }


}
