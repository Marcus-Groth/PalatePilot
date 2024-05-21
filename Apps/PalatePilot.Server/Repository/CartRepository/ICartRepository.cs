using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Repository
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartAsync(string userId);
        Task CreateCartAsync(Cart cart);
        Task SaveCartAsync();
        Task DeleteAsync(Cart cart);
    }
}