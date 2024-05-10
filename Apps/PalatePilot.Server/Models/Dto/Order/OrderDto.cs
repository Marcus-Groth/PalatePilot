using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Dto.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public virtual List<OrderItemDto> OrderItems { get; set; } = new();
    }
}