using Microsoft.Extensions.Configuration;
using PCWebShop.Core.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PCWebShop.Core.Services
{
    public class EmailSender : IEmailSender
    {

        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;

        }
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage(fromAddress, toAddress, subject, message);

            using (var client = new SmtpClient(_config["SMTP2:Host"], int.Parse(_config["SMTP2:Port"]))
            {
                Credentials = new NetworkCredential(_config["SMTP2:Username"], _config["SMTP2:Password"]),
                
            })
            {
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
