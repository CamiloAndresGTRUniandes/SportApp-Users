namespace Users.Infraestructure.Email ;
using System.Net;
using Aplication.Contracts.Infraestructure;
using Aplication.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings;
        public ILogger<IEmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<IEmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress
            {
                Email = email.To
            };

            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };


            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Accepted)
            {
                return true;
            }
            _logger.LogError("No se´pudo enviar el correo");

            return false;
        }
    }
