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
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto.Order;
using Serilog;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly PalatePilotDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(PalatePilotDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
   
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var cart = await _context.Carts
                .Include(cart => cart.CartItems)
                .ThenInclude(cartItem => cartItem.Food)
                .FirstOrDefaultAsync(cart => cart.UserId == userId); 

            if(cart == null)
            {
                return NotFound();
            }

            var order = new Order{UserId = cart.UserId};
            order.AddItem(cart.CartItems);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, "New order has been created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var orderList = await _context.Orders
                .Where(order => order.UserId == userId)
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.Food)
                .ToListAsync();

            if(orderList == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<OrderDto>>(orderList));
        }   

    }
}