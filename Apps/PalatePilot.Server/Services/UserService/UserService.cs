using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.EmailService;
using Serilog;

namespace PalatePilot.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManger;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public UserService(UserManager<User> userManager, IConfiguration config, IEmailService emailService)
        {
            _userManger = userManager;
            _config = config;
            _emailService = emailService;
        }

        public async Task Registration(RegistrationDto request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var result = await _userManger.CreateAsync(newUser, request.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    Log.Error("Registration Process: {@Error}", error);
                }
                
                throw new BadRequestException("Registration Unsuccessful");
            }
                                
            await _userManger.AddToRolesAsync(newUser, ["User"]);

            // Generate email confirmation token
            var token = await _userManger.GenerateEmailConfirmationTokenAsync(newUser);
            var url = _config["UrlConfig:ConfirmEmail"];
            
            // Append token and email to the url
            var confirmationLink = QueryHelpers.AddQueryString(url,
                new Dictionary<string, string?>
                {
                    {"token", token},
                    {"email", request.Email}
                }
            );

            var emailRequest = new EmailDto
            {
                Email = newUser.Email,
                Username = newUser.UserName,
                Subject = "Account Registration Confirmation",
                Message = $"Dear {newUser.UserName},<br><br>" +
                          $"Thank you for registering an account with us!<br><br>" +
                          $"To activate your account, please click on the following link:<br>" +
                          $"<a href=\"{confirmationLink}\">{confirmationLink}</a><br><br>" +
                        $"Please note that this link will expire in 1 hour."
            };
 
            await _emailService.SendEmailAsync(emailRequest);
        }
    }
}