using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification.SendEmail;
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
    }
}
