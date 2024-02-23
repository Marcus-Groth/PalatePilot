using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.Exceptions;
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
        [ValidateModel]
        public async Task<IActionResult> Registration(RegistrationRequestDto request)
        {
            
            await _authService.Registration(request);
            
            // Generate success response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Created",
                message: "User has been created successfully."
            );
            
            return Created(nameof(Registration), response);            
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            return Ok(await _authService.Login(request));
        }
    }
}