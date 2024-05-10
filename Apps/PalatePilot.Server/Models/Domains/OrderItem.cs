using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Domains
{
    [Table("OrderItems")]
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }

       
        // Navigation properties
        public Order Order { get; set; } = null!;
        public Food Food { get; set; } = null!;
    }
}