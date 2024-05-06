using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Services.CartService
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(string userId);
    }
}