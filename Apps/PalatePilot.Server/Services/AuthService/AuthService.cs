using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.WebUtilities;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.EmailService;
using Serilog;

namespace PalatePilot.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManger;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public AuthService(UserManager<User> userManager, ITokenService tokenService, IEmailService emailService, IConfiguration config)
        {
            _userManger = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _config = config;
        }


        public async Task<string> Login(LoginDto request)
        {
            var fetchedUser = await _userManger.FindByNameAsync(request.UserName);
            if(fetchedUser == null || !await _userManger.CheckPasswordAsync(fetchedUser, request.Password))
            {
                throw new UnauthorizedException("Invalid Username or Password");
            }
                
            if(!await _userManger.IsEmailConfirmedAsync(fetchedUser))
            {
                throw new ForbiddenException("Your email address has not yet been confirmed. Please check your inbox for the confirmation email.");
            }

            var roles = await _userManger.GetRolesAsync(fetchedUser);
            return _tokenService.GenerateToken(fetchedUser, roles.ToList());
        }

       

        public async Task ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var fetchedUser = await _userManger.FindByEmailAsync(forgotPasswordDto.Email);
            if(fetchedUser == null)
            {
                throw new NotFoundException("No email exist with this name");
            }

            // Generate email confirmation token
            var token = await _userManger.GeneratePasswordResetTokenAsync(fetchedUser);
            var url = _config["UrlConfig:ResetPassword"];

            // Append token and email to the url
            var resetPasswordLink = QueryHelpers.AddQueryString(url,
                new Dictionary<string, string?>
                {
                    {"token", token},
                    {"email", fetchedUser.Email}
                }
            );

            var emailRequest = new EmailDto
            {
                Email = fetchedUser.Email,
                Username = fetchedUser.UserName,
                Subject = "Reset Password",
                Message = $"Dear {fetchedUser.UserName},<br><br>" +
                            $"You recently requested to reset your password. If you did not make this request, please ignore this email.<br><br>" +
                            $"To reset your password, click on the following link:<br>" +
                            $"<a href=\"{resetPasswordLink}\">{resetPasswordLink}</a><br><br>" +
                        $"Please note that this link will expire in 1 hour."
            };

            await _emailService.SendEmailAsync(emailRequest);
        }

        public async Task ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var fetchedUser = await _userManger.FindByEmailAsync(resetPasswordDto.Email);
            if(fetchedUser == null)
            {
                throw new NotFoundException("No email exist with this name");
            }

            var result = await _userManger.ResetPasswordAsync(fetchedUser, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    Log.Error("ResetPassword Process: {@Error}", error);
                }

                throw new BadRequestException("Failed to reset your password");
            }

            var emailRequest = new EmailDto
            {
                Email = fetchedUser.Email,
                Username = fetchedUser.UserName,
                Subject = "Your Password Has Been Successfully Reset",
                
                Message = "Dear " + fetchedUser.UserName + ",\n\n" + 
                          "This email is to confirm that your password " +
                          "has been successfully reset. If you did not initiate this " +
                          "change, please contact our support team immediately, as this " +
                          "could indicate unauthorized access to your account."
            };
 
            await _emailService.SendEmailAsync(emailRequest);
        }

        public async Task EmailConfirmation(string token, string email)
        {
            var fetchedUser = await _userManger.FindByEmailAsync(email);
            if(fetchedUser == null)
            {
                throw new BadRequestException("No email exist with this name");
            }

            var confirmResult = await _userManger.ConfirmEmailAsync(fetchedUser, token);
            if(!confirmResult.Succeeded)
            {
                foreach(var error in confirmResult.Errors)
                {
                    Log.Error("Email Confirmation Process: {@Error}", error);
                }
                
                throw new BadRequestException("Your confirm email link has been expired or invalid");
            }
        }
    }
}