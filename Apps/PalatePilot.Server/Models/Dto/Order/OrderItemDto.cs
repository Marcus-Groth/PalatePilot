using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Dto.Order
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public FoodDto Food { get; set; } = new();
    }
}