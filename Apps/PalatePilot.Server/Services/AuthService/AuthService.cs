using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PalatePilot.Server.ExceptionHandlers;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _userManger = userManager;
            _tokenService = tokenService;
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
                throw new BadRequestException("Registration Unsuccessful");
                                
            // Assign role to user
            await _userManger.AddToRolesAsync(newUser, ["User"]);
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
    }
}