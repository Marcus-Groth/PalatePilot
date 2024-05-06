using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Repository;

namespace PalatePilot.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly  IMapper _mapper;
        public CartService(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
         
        public async Task<CartDto> GetCartAsync(string userId)
        {
            var cart = await _repository.GetCartAsync(userId);
            if (cart == null)
            {
                throw new NotFoundException($"No cart exist for user {userId}");
            }

            return _mapper.Map<CartDto>(cart);
        }
    }
}