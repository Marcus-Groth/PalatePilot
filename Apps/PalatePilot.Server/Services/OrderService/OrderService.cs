using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Repository;
using PalatePilot.Server.Repository.OrderRepository;

namespace PalatePilot.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateAsync(ShippingAddressDto shippingAddressDto, string userId)
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            if (cart == null)
            {
                throw new NotFoundException($"No cart exist for user {userId}");
            }

            var orderItems = new List<OrderItem>();
            
            foreach(CartItem cartItem in cart.CartItems)
            {
                orderItems.Add(new OrderItem 
                {
                    Name = cartItem.Food.Name,
                    Price = cartItem.Food.Price,
                    Quantity = cartItem.Quantity
                });
            }

            var shippingAddress = _mapper.Map<ShippingAddress>(shippingAddressDto);

            var newOrder = new Order 
            {
                UserId = userId,
                ShippingAddress = shippingAddress,
                SubTotal = orderItems.Sum(orderItem => orderItem.Price * orderItem.Quantity),
                OrderItems = orderItems
            };

            await _orderRepository.CreatAsync(newOrder);

            return _mapper.Map<OrderDto>(newOrder);
        }
    }
}