using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    }
}