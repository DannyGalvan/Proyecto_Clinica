using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Entities.Models;
using Business.Interfaces;

namespace Business.Repository
{
    public class Mail : IMail
    {
        private readonly AppSettings _appSettings;
        public Mail(IOptions<AppSettings> configuration)
        {
            _appSettings = configuration.Value;
        }

        public bool Send(string email, string affair, string message)
        {
            bool result;

            try
            {
                MailMessage mail = new();
                mail.To.Add(email);
                mail.From       = new MailAddress(_appSettings.Email);
                mail.Subject    = affair;
                mail.Body       = message;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                           {
                               Credentials = new NetworkCredential(_appSettings.Email, _appSettings.EmailCredentials),
                               Host        = "smtp.gmail.com",
                               Port        = 587,
                               EnableSsl   = true,
                           };

                smtp.Send(mail);
                result = true;

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
