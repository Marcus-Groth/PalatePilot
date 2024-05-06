using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Data.Contexts;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.CartService;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        
        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cartDto = await _service.GetCartAsync(userId);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "Your cart has been successfully retrieved.",
                data: cartDto
            );

            return Ok(response);  
        }

        
    }
}