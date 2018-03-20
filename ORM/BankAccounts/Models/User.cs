using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public abstract class BaseEntity
    {
        // EMPTY!!!
    }
    public class User : BaseEntity
    {
        // These must match your column in your table database!
        [Key]
        public int UserID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="First Name must be at least 2 characters!")]
        public string FirstName { get;set; }
    
        [Required]
        [MinLength(2, ErrorMessage="Last Name must be at least 2 characters!")]
        public string LastName { get;set; }

        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        public string Password { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        public string ConfirmPassword { get;set; }
    }
}