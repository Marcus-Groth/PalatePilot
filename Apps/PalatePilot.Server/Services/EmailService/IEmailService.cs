using System;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequestDto request);
    }
}