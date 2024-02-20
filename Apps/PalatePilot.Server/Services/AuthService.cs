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
            // Generate new user
           var newUser = new IdentityUser
           {
                UserName = request.UserName,
                Email = request.Email
           };

            // hash password and save user to the database
            var result = await _userManger.CreateAsync(newUser, request.Password);

            if(!result.Succeeded) return false;

            await _userManger.AddToRolesAsync(newUser, ["User"]);
            return true;
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