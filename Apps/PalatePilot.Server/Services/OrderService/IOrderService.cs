using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(ShippingAddressDto shippingAddressDto, string userId);
        Task<OrderDto> GetByIdAsync(int orderId, string userId);
        Task<List<OrderDto>> GetAllAsync(string userId);
    }
}