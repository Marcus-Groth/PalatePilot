using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.OrderService;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShippingAddressDto shippingAddressDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orderDto = await _orderService.CreateAsync(shippingAddressDto, userId);

            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Create",
                message: "Order was successfully created"
            );

            return CreatedAtAction(nameof(GetById), new { id = orderDto.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orderListDto = await _orderService.GetAllAsync(userId);

            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "List of orders has been retrieved successfully",
                data: orderListDto
            );

            return Ok(response);
        }   

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orderDto = await _orderService.GetByIdAsync(orderId, userId);

            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "Order was successfully created",
                data: orderDto
            );

            return Ok(response);
        }     
    }
}