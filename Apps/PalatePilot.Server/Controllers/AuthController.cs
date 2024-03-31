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
        public async Task<IActionResult> Registration(RegistrationDto request)
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
        public async Task<IActionResult> Login(LoginDto request)
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
                message: "Password reset link has been sent to your email."
            );

            return Created(nameof(Login), response); 
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            // Call Reset Password service
            await _authService.ResetPassword(resetPasswordDto);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title:"Create",
                message: "Your Password Has Been Successfully Reset"
            );

            return Created(nameof(ForgotPassword), response); 
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

        

        [HttpGet("ResetPassword")]
        public IActionResult ResetPassword([FromQuery] string token, [FromQuery] string email)
        {
            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "Ok",
                message: "",
                data: new {Token = token, Email = email}
            );

            return Ok(response);
        } 
    }
}