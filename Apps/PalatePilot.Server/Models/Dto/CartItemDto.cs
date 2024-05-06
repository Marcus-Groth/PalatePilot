using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Models.Dto
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public FoodDto Food { get; set; } = new();
    }
}