using Microsoft.AspNetCore.Identity;
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

         public async Task<bool> Registration(RegistrationRequestDto request)
        {
           var newUser = new IdentityUser
           {
            UserName = request.UserName,
            Email = request.Email
           };

            // Create a new user and hash the password
            var result = await _userManger.CreateAsync(newUser, request.Password);

            if(result.Succeeded)
            {
                // Add roles to this user
                if(request.Roles.Length > 0)
                {
                    await _userManger.AddToRolesAsync(newUser, request.Roles);

                    if(result.Succeeded)
                    {
                        return true;
                    }   
                }
            }

            return false;
        }

        public async Task<string> Login(LoginRequestDto request)
        {
            // Fetch User by Name from database
            var fetchedUser = await _userManger.FindByNameAsync(request.UserName);
            
            // Check if user exists
            if(fetchedUser != null)
            {  
                // Check if password was correct 
                var checkPasswordResult = await _userManger.CheckPasswordAsync(fetchedUser, request.Password);
                if(checkPasswordResult)
                {
                    
                    var roles = await _userManger.GetRolesAsync(fetchedUser);
                    if(roles != null)
                    {
                        // Create a token for the user
                       var jwtToken = _tokenService.GenerateToken(request, roles.ToList());
                       return jwtToken;
                    }
                }
            }
           
            return null;
        }
    }
}