using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Domains
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<CartItem> CartItems { get; set; } = new();

        public void AddItem(Food food, int quantity)
        {
            if(CartItems.All(i => i.FoodId != food.Id))
            {
                CartItems.Add(new CartItem{Food = food, Quantity = quantity});
            }

            var existingItem = CartItems.FirstOrDefault(i => i.FoodId == food.Id);
            if(existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
        }
    }
}