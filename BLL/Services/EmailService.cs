using BLL.EmailEntity;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            var email = new MailMessage
            {
                From = new MailAddress("rullesexpre@gmail.com"),
                Subject = message.Subject,
                Body = message.Text
            };

            email.To.Add(new MailAddress(message.To));

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("rullesexpre@gmail.com", "qxmhwrbqvlakfrxk"),
                EnableSsl = true
            };
           
            await smtpClient.SendMailAsync(email);
        }
    }
}
