using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace OechsleTest.Console.Utils
{
    public class SendMail
    {
        public static void Send(string subject, string to, string from, string body, Stream file, string fileName)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("andy.r3@gmail.com", "gezuehylexlnopas")
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = body
                };
                mailMessage.To.Add(to);
                if (file.Length > 0)
                {
                    file.Seek(0, SeekOrigin.Begin);
                    var attachment = new Attachment(file, fileName);
                    mailMessage.Attachments.Add(attachment);
                }

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar (Configurar datos del servidor de correos): {ex.Message}");
            }
        }
    }
}