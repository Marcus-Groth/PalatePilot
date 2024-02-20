using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.Models;
using PalatePilot.Server.Services;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        // POST: api/Auth/Registration
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationRequestDto request)
        {
            if(await _authService.Registration(request))
            {
                return Ok("Registration Successful");
            }

            return BadRequest("Registration Failed"); 
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            return Ok(await _authService.Login(request));
        }
    }
}