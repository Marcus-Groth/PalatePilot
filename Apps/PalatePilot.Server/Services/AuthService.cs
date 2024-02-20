using Microsoft.AspNetCore.Identity;
using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManger;
        public AuthService(UserManager<IdentityUser> userManager)
        {
            _userManger = userManager;
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
    }
}