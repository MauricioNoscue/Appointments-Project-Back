using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification.SendEmail;
using Entity_Back.Enum;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;

namespace Utilities_Back.Helper
{
    public static  class SendCitation
    {
        public static string SendCitaionTemaplate(SendCitationDto dto)
        {
            try
            {
                var cuerpo = $@"
                        <div style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
                          <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; padding: 30px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
    
                            <h2 style=""color: #4CAF50; text-align:center;"">¡Tu cita ha sido programada!</h2>
    
                            <p style=""font-size: 16px; color: #333;"">
                              Hola <strong>{dto.Email}</strong>, te confirmamos que tu cita se ha agendado exitosamente con los siguientes detalles:
                            </p>

                            <table style=""width:100%; border-collapse: collapse; margin-top: 20px;"">
                              <tr>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Fecha:</strong></td>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{dto.Date:dddd, dd MMMM yyyy}</td>
                              </tr>
                              <tr>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Hora:</strong></td>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{dto.TimeBlock}</td>
                              </tr>
                              <tr>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Estado:</strong></td>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">Programada</td>
                              </tr>
                              <tr>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Lugar:</strong></td>
                                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">Clínica Central - Sala de Consultas</td>
                              </tr>
                            </table>

                            <p style=""font-size: 14px; color: #666; margin-top: 20px;"">
                              Te recomendamos llegar 10 minutos antes de tu cita. Si no puedes asistir, por favor reprograma con anticipación desde la plataforma.
                            </p>

                            <div style=""margin-top: 30px; text-align: center;"">
                              <a href=""{dto.UrlRedirect}"" style=""background-color: #4CAF50; color: white; padding: 12px 24px; text-decoration: none; border-radius: 5px; display: inline-block;"">
                                Ver mis citas
                              </a>
                            </div>

                            <hr style=""margin-top: 40px; border: none; border-top: 1px solid #eee;"" />

                            <p style=""font-size: 12px; color: #aaa; text-align: center;"">
                              Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.
                            </p>
                          </div>
                        </div>
                        ";

                return cuerpo;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar la plantilla de correo para la cita: " + ex.Message);

            }
        }




        public static string BuildCitationTemplate(CitationEmailType type, SendCitationDto dto)
        {
            try
            {
                // 🟦 Texto dinámico según tipo
                string title;
                string description;
                string estado;

                switch (type)
                {
                    case CitationEmailType.Created:
                        title = "¡Tu cita ha sido programada!";
                        description = $"Hola <strong>{dto.Email}</strong>, tu cita ha sido agendada exitosamente. Aquí tienes los detalles:";
                        estado = "Programada";
                        break;

                    case CitationEmailType.Rescheduled:
                        title = "¡Tu cita ha sido reprogramada!";
                        description = $"Hola <strong>{dto.Email}</strong>, tu cita fue reprogramada. A continuación encuentras la nueva información:";
                        estado = "Reprogramada";
                        break;

                    case CitationEmailType.Canceled:
                        title = "Tu cita ha sido cancelada";
                        description = $"Hola <strong>{dto.Email}</strong>, lamentamos informarte que tu cita ha sido cancelada.";
                        estado = "Cancelada";
                        break;

                    default:
                        throw new Exception("Tipo de correo no soportado.");
                }

                // 🟥 Plantilla base HTML (igual para todos)
                var cuerpo = $@"
                <div style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
                  <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; padding: 30px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
    
                    <h2 style=""color: #4CAF50; text-align:center;"">{title}</h2>

                    <p style=""font-size: 16px; color: #333;"">
                      {description}
                    </p>

                    <table style=""width:100%; border-collapse: collapse; margin-top: 20px;"">
                      <tr>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Fecha:</strong></td>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{dto.Date:dddd, dd MMMM yyyy}</td>
                      </tr>
                      <tr>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Hora:</strong></td>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{dto.TimeBlock}</td>
                      </tr>
                      <tr>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Estado:</strong></td>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{estado}</td>
                      </tr>
                      <tr>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Lugar:</strong></td>
                        <td style=""padding: 10px; border-bottom: 1px solid #eee;"">Clínica Central - Sala de Consultas</td>
                      </tr>
                    </table>

                    <p style=""font-size: 14px; color: #666; margin-top: 20px;"">
                      Te recomendamos llegar 10 minutos antes de tu cita. Si no puedes asistir, recuerda reprogramar o gestionar tu cita desde la plataforma.
                    </p>

                    <div style=""margin-top: 30px; text-align: center;"">
                      <a href=""{dto.UrlRedirect}"" style=""background-color: #4CAF50; color: white; padding: 12px 24px; text-decoration: none; border-radius: 5px; display: inline-block;"">
                        Ver mis citas
                      </a>
                    </div>

                    <hr style=""margin-top: 40px; border: none; border-top: 1px solid #eee;"" />

                    <p style=""font-size: 12px; color: #aaa; text-align: center;"">
                      Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.
                    </p>
                  </div>
                </div>
            ";

                return cuerpo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar plantilla de correo: " + ex.Message);
            }
        }


        public static string BuildRequestTemplate(RequestEmailType type, ModificationRequest request, string email, string url)
        {
            string title;
            string description;
            string estado;

            switch (type)
            {
                case RequestEmailType.Approved:
                    title = "¡Tu solicitud ha sido aprobada!";
                    description = $"Hola <strong>{email}</strong>, tu solicitud fue aprobada exitosamente. Aquí tienes los detalles:";
                    estado = "Aprobada";
                    break;

                case RequestEmailType.Rejected:
                    title = "Tu solicitud ha sido rechazada";
                    description = $"Hola <strong>{email}</strong>, lamentamos informarte que tu solicitud fue rechazada. Puedes revisar la información a continuación:";
                    estado = "Rechazada";
                    break;

                default:
                    throw new Exception("Tipo de correo no soportado.");
            }

            string start = request.StartDate?.ToString("dddd, dd MMMM yyyy") ?? "No aplica";
            string end = request.EndDate?.ToString("dddd, dd MMMM yyyy") ?? "No aplica";

            string observation = string.IsNullOrWhiteSpace(request.Observation)
                ? "N/A"
                : request.Observation;

            // PLANTILLA HTML IGUAL A LAS CITAS
            return $@"
    <div style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
      <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; padding: 30px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">

        <h2 style=""color: #4CAF50; text-align:center;"">{title}</h2>

        <p style=""font-size: 16px; color: #333;"">
          {description}
        </p>

        <table style=""width:100%; border-collapse: collapse; margin-top: 20px;"">
          <tr>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Tipo de Solicitud:</strong></td>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{request.TypeRequest}</td>
          </tr>
          <tr>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Razón:</strong></td>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{request.Reason}</td>
          </tr>
          <tr>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Fecha Inicio:</strong></td>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{start}</td>
          </tr>
          <tr>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Fecha Fin:</strong></td>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{end}</td>
          </tr>
          <tr>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Observación:</strong></td>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{observation}</td>
          </tr>
          <tr>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Estado:</strong></td>
            <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{estado}</td>
          </tr>
        </table>

        <div style=""margin-top: 30px; text-align: center;"">
          <a href=""{url}"" style=""background-color: #4CAF50; color: white; padding: 12px 24px; text-decoration: none; border-radius: 5px; display: inline-block;"">
            Ver solicitud
          </a>
        </div>

        <hr style=""margin-top: 40px; border: none; border-top: 1px solid #eee;"" />

        <p style=""font-size: 12px; color: #aaa; text-align: center;"">
          Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.
        </p>

      </div>
    </div>";
        }

        public static string BuildCitationStatusTemplate(User user, Entity_Back.Citation citation)
        {
            try
            {
                string title;
                string description;
                string estado;

                switch (citation.StatustypesId)
                {
                    case 3: // No Asistida
                        title = "Tu cita fue marcada como No Asistida";
                        description = $"Hola <strong>{user.Email}</strong>, tu cita programada no registró asistencia.";
                        estado = "No Asistida";
                        break;

                    case 4: // Atendida
                        title = "¡Tu cita fue atendida con éxito!";
                        description = $"Hola <strong>{user.Email}</strong>, tu cita fue completada correctamente. Gracias por asistir.";
                        estado = "Atendida";
                        break;

                    default:
                        throw new Exception("Estado de cita no soportado para plantilla.");
                }

                var cuerpo = $@"
        <div style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
          <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; padding: 30px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
    
            <h2 style=""color: #4CAF50; text-align:center;"">{title}</h2>

            <p style=""font-size: 16px; color: #333;"">
              {description}
            </p>

            <table style=""width:100%; border-collapse: collapse; margin-top: 20px;"">
              <tr>
                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Fecha:</strong></td>
                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{citation.AppointmentDate:dddd, dd MMMM yyyy}</td>
              </tr>
              <tr>
                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Hora:</strong></td>
                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{citation.TimeBlock}</td>
              </tr>
              <tr>
                <td style=""padding: 10px; border-bottom: 1px solid #eee;""><strong>Estado:</strong></td>
                <td style=""padding: 10px; border-bottom: 1px solid #eee;"">{estado}</td>
              </tr>
            </table>

            <p style=""font-size: 14px; color: #666; margin-top: 20px;"">
              Puedes consultar el historial de tus citas en la plataforma.
            </p>

            <div style=""margin-top: 30px; text-align: center;"">
              <a href=""https://localhost:4200/citations"" style=""background-color: #4CAF50; color: white; padding: 12px 24px; text-decoration: none; border-radius: 5px; display: inline-block;"">
                Ver mis citas
              </a>
            </div>

            <hr style=""margin-top: 40px; border: none; border-top: 1px solid #eee;"" />

            <p style=""font-size: 12px; color: #aaa; text-align: center;"">
              Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.
            </p>
          </div>
        </div>";

                return cuerpo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar plantilla de estado de cita: " + ex.Message);
            }
        }


    }
}
