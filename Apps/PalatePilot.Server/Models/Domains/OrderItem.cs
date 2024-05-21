using System.ComponentModel.DataAnnotations.Schema;

namespace PalatePilot.Server.Models.Domains
{
    [Table("OrderItems")]
    public class OrderItem
    {
        public int Id { get; set; }  
        public int OrderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Quantity { get; set; }        
    }
}