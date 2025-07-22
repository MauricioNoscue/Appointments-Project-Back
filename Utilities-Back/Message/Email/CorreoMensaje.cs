using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Utilities_Back.Message.Email
{
    public static class CorreoMensaje
    {
        public static async Task EnviarAsync(IConfiguration configuration, string destinatario, string asunto, string contenido)
        {
            var smtpConfig = configuration.GetSection("SmtpSettings");

            var mensaje = new MailMessage
            {
                From = new MailAddress(smtpConfig["Email"]),
                Subject = asunto,
                Body = contenido,
                IsBodyHtml = true
            };

            mensaje.To.Add(destinatario);

            using var client = new SmtpClient
            {
                Host = smtpConfig["Host"],
                Port = int.Parse(smtpConfig["Port"]),
                EnableSsl = bool.Parse(smtpConfig["EnableSsl"]),
                Credentials = new NetworkCredential(smtpConfig["Email"], smtpConfig["Password"])
            };

            await client.SendMailAsync(mensaje);
        }
    }
}
