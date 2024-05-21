using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Domains
{
    // Dependent (Child)
    [Table("CartItems")]
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }    

        // Navigation properties
        public Food Food { get; set; } = null!;
        public virtual Cart Cart { get; set; } = null!;
    }
}