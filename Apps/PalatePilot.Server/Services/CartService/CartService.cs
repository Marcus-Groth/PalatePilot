using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Repository;
using PalatePilot.Server.Services.FoodService;

namespace PalatePilot.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly  IMapper _mapper;
        public CartService(ICartRepository cartRepository, IFoodRepository foodRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task AddItemToCart(string userId, int foodId, int quantity)
        {
            // Get Cart
            var cart = await _cartRepository.GetCartAsync(userId);
            
            // Create cart if not exist
            if(cart == null)
            {
                cart = new Cart{UserId = userId};
                await _cartRepository.CreateCartAsync(cart);
            }

            // Get food item
            var food = await _foodRepository.GetByIdAsync(foodId);
            if(food == null)
            {
                throw new NotFoundException("The specified food could not be found. Please check the ID and try again");
            }

            cart.AddItem(food, quantity);
            await _cartRepository.SaveCartAsync();
        }

        public async Task<CartDto> GetCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            if (cart == null)
            {
                throw new NotFoundException($"No cart exist for user {userId}");
            }

            return _mapper.Map<CartDto>(cart);
        }
    }
}