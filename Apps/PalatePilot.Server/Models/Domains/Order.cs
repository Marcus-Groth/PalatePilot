using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Domains
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();

        public void AddItem(List<CartItem> cartItems)
        {
            foreach(CartItem cartItem in cartItems)
            {
                OrderItems.Add(new OrderItem
                {
                    Food = cartItem.Food,
                    Quantity = cartItem.Quantity
                });   
            }
        }
    }
}