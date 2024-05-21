using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreatAsync(Order order);
    }
}