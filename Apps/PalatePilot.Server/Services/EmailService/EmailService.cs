using System;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using PalatePilot.Server.Configs;
using PalatePilot.Server.Models.Dto;
namespace PalatePilot.Server.Services.EmailService
{
    public class EmailService
    {
        private readonly EmailConfig _emailConfig;
        public EmailService(IOptions<EmailConfig> emailConfigOptions)
        {
            _emailConfig = emailConfigOptions.Value;
        }

        private MimeMessage CreateEmailMessage(EmailRequestDto request)
        {
            // Initialize the email message
            var emailMessage = new MimeMessage();
            
            // Generate a email sender
            MailboxAddress sender = new MailboxAddress(_emailConfig.Username, _emailConfig.Email);
            emailMessage.From.Add(sender);
            
            // Generate a email receiver
            MailboxAddress receiver = new MailboxAddress(request.Username, request.Email);
            emailMessage.To.Add(receiver);

            // Generate a email subject
            emailMessage.Subject = request.Subject;

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = request.Message };
            return emailMessage;
        }
    }
}