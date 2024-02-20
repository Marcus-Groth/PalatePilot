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

    }
}