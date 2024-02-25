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
    }
}