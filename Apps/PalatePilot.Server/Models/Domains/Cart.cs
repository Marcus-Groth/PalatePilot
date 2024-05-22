using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Exceptions;

namespace PalatePilot.Server.Models.Domains
{
    
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int SubTotal { get; set; }
        
        // Navigation property
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

            SubTotal = SubTotal + (food.Price * quantity);
        }

        public void RemoveItem(Food food)
        {
            var existingItem = CartItems.FirstOrDefault(i => i.FoodId == food.Id);
            if(existingItem != null)
            {
                existingItem.Quantity --;

                if(existingItem.Quantity <= 0)
                {
                    CartItems.Remove(existingItem);
                }
            }

            else 
            {
                throw new NotFoundException($"No food item found in the cart with Id: {food.Id}");
            }
        }
    }
}