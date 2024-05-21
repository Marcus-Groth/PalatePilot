using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PalatePilot.Server.Models.Domains
{
    [Owned]
    public class ShippingAddress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}