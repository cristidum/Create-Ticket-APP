using System.Net.Mail;
using System.Net;
using Ticket_App.Interfaces;

namespace Ticket_App.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "";
            var pw = "";

            var client = new SmtpClient("", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                message));
        }
    }
}
