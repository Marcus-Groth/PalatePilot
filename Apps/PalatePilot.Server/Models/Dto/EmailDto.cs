using System;
using System.ComponentModel.DataAnnotations;
namespace PalatePilot.Server.Models.Dto
{
    public class EmailDto
    {
        /// <summary>
        /// Email
        /// </summary>
        /// <example>makenzie.schiller51@ethereal.email</example>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Username
        /// </summary>
        /// <example>Makenzie Schiller</example>
        [Required]
        public string Username { get; set; } = string.Empty;
        
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}