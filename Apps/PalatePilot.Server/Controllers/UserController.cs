using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.CustomActionFilters;
using PalatePilot.Server.Models;
using PalatePilot.Server.Services.UserService;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/Auth/Registration
        [HttpPost("Registration")]
        [ValidateModel]
        public async Task<IActionResult> Registration(RegistrationDto registrationDto)
        {
            // Call registration service
            await _userService.Registration(registrationDto);
            
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
    }
}