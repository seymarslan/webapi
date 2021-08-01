using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace WEBAPI.Business
{
    public interface IEmailService
    {
        void Send(string from, string to, string subject, string html);
    }

    public class EmailService : IEmailService
    {

        public EmailService()
        {
        }

        public void Send(string to, string subject, string html, string from = "seymaaslan.projemail@gmail.com")
        {
            try
            {

                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("seymaaslan.projemail@gmail.com", "seyma.123");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
