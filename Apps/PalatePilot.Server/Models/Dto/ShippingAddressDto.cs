using System.ComponentModel.DataAnnotations;

namespace PalatePilot.Server.Models.Dto
{
    public class ShippingAddressDto
    {
        /// <summary>
        /// The first name of the recipient
        /// </summary>
        /// <example>jarrod</example>
        [Required]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the recipient
        /// </summary>
        /// <example>Doe</example>
        [Required]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the recipient
        /// </summary>
        /// <example>jarrod81@ethereal.email</example>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        /// <example>+1234567890</example>
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// The street address of the recipient
        /// </summary>
        /// <example>123 Main St, Apt 4B</example>
        [Required]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city of the recipient
        /// </summary>
        /// <example>Springfield</example>
        [Required]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The postal code of the recipient
        /// </summary>
        /// <example>12345</example>
        [Required]
        public string PostalCode { get; set; } = string.Empty;
    }
}