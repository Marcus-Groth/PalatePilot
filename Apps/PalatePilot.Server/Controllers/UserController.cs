using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.CustomActionFilters;
using PalatePilot.Server.Models;
using PalatePilot.Server.Services;
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

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetById(id);

            var respose = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "Ok",
                message: $"User information retrieved successfully for Id {id}",
                data: user
            );

            return Ok(respose);
        }
    }
}