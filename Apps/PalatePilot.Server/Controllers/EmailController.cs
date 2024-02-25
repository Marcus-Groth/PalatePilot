using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.EmailService;

namespace PalatePilot.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
 
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("SendEmail")]
        
        public async Task<IActionResult> SendEmail(EmailRequestDto request)
        {
            await _emailService.SendEmailAsync(request);

             // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Created",
                message: "Email has been sent!"
            );

            return Created(nameof(SendEmail), response);
        }
    }
}