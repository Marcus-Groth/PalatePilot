using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Models.Dto
{
    public class OrderDto
    {   
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ShippingAddress ShippingAddress { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();        
        public int SubTotal { get; set; }        
    }
}