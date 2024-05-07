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

        [HttpPost, Authorize]
        public async Task<IActionResult> AddItemToCart(int foodId, int quantity)
        {            
            // Get authenticated user id
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.AddItemToCart(userId, foodId, quantity);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Create",
                message: "Food item has been successfully added to your cart"
            );

            return Ok(response);  
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

        [HttpDelete, Authorize]
        public async Task<IActionResult> RemoveItemToCart(int foodId)
        {
            // Get authenticated user id
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.RemoveItemFromCart(userId, foodId);

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Ok",
                message: "Food item has been successfully deleted from the cart"
            );

            return Ok(response);  

        }
    }
}