using System.ComponentModel.DataAnnotations;

namespace PalatePilot.Server.Models
{
    public class LoginDto
    {
        /// <summary>
        /// Username
        /// </summary>
        /// <example>jarrod</example>
        [Required]
        public string UserName { get; set; } = string.Empty;
        
        /// <summary>
        /// Password
        /// </summary>
        /// <example>Passw0rd!</example>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}