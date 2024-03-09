using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.CustomActionFilters;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Dto;
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
            // Call registration service
            await _authService.Registration(request);
            
            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Created",
                message: "Registration Successfull."
            );
            
            // Return successfull response
            return Created(nameof(Registration), response);            
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            // Call login service
            string jwtToken = await _authService.Login(request);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Created",
                message: "Login Successfull.",
                data: jwtToken
            );

            // Return successfull response
            return Created(nameof(Login), response); 
        }

        [HttpGet("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string token, [FromQuery] string email)
        {
            // Call login service
            await _authService.EmailConfirmation(token, email);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "Email Confirmation Successfull."
            );

            return Ok(response);  
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            // Call forgot password service
            await _authService.ForgotPassword(forgotPasswordDto);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Create",
                message: "Password reset link sent to your email."
            );

            return Created(nameof(Login), response); 
        }
    }
}