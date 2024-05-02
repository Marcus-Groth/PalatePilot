using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.CustomActionFilters;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Services;
using PalatePilot.Server.Services.UserService;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
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

        [HttpGet("GetById")]
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
        
        [Authorize]
        [HttpGet("GetCurrent")] 
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userService.GetCurrent(User);
            
            var respose = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "Ok",
                message: $"User information retrieved successfully",
                data: user
            );

            return Ok(respose);            
        }
    }
}