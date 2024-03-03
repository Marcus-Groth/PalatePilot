using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.EmailService;

namespace PalatePilot.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService, IEmailService emailService)
        {
            _userManger = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task Registration(RegistrationRequestDto request)
        {
            // Create new User
           var newUser = new IdentityUser
           {
                UserName = request.UserName,
                Email = request.Email
           };

            // hash password and save user to the database
            var result = await _userManger.CreateAsync(newUser, request.Password);

            // Throw exception if registration was unsuccessful
            if(!result.Succeeded)
            {
                throw new BadRequestException("Registration Unsuccessful");
            }
                                
            // Assign role to user
            await _userManger.AddToRolesAsync(newUser, ["User"]);

            // Generate email confirmation token
            var token = await _userManger.GenerateEmailConfirmationTokenAsync(newUser);
            
            // Add token and email to dictionary
            var param = new Dictionary<string, string>
            {
                {"token", token},
                {"email", request.Email}
            };

            // Generate email confirmation link
            var confirmationLink = QueryHelpers.AddQueryString(
                "https://localhost:7200/api/Auth/EmailConfirmation",
                 param
            );

            // Generate email confirmation message
            var emailRequest = new EmailRequestDto
            {
                Email = request.Email,
                Username = request.UserName,
                Subject = "Email Confirmation",
                Message = confirmationLink
            };
 
            await _emailService.SendEmailAsync(emailRequest);
        }

        public async Task<string> Login(LoginRequestDto request)
        {
            // Fetch User by Name from database
            var fetchedUser = await _userManger.FindByNameAsync(request.UserName);
            if(fetchedUser == null || !await _userManger.CheckPasswordAsync(fetchedUser, request.Password))
            {
                throw new UnauthorizedException("Invalid Username or Password");
            }
                
            if(!await _userManger.IsEmailConfirmedAsync(fetchedUser))
            {
                throw new UnauthorizedException("Email not confirmed");
            }

            var roles = await _userManger.GetRolesAsync(fetchedUser);

            return _tokenService.GenerateToken(fetchedUser, roles.ToList());
        }

        public async Task EmailConfirmation(string token, string email)
        {
            var fetchedUser = await _userManger.FindByEmailAsync(email);
            if(fetchedUser == null)
            {
                throw new BadRequestException("Invalid Email Confirmation Request");
            }

            var confirmResult = await _userManger.ConfirmEmailAsync(fetchedUser, token);
            if(!confirmResult.Succeeded)
            {
                throw new BadRequestException("Invalid Email Confirmation Request");
            }
        }
    }
}