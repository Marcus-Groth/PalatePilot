using System;
using System.ComponentModel.DataAnnotations;
namespace PalatePilot.Server.Models.Dto
{
    public class EmailDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Username { get; set; } = string.Empty;
        
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}