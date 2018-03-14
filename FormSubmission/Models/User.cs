using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
 
namespace FormSubmission.Models
{
    public abstract class BaseEntity
    {
        // BASE ENTITY IS LEFT EMPTY!!!
    }
    public class User : BaseEntity
    {
        [Required(ErrorMessage="First Name field is required.")]
        [MinLength(2, ErrorMessage="First Name should be more than 2 characters!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last Name field is required.")]
        [MinLength(2, ErrorMessage="Last Name should be more than 2 characters!")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Age field is required.")]
        [Range(0,120,ErrorMessage="Age must be between 0 and 120")]
        public string Age { get; set; }
 
        [Required(ErrorMessage="Email Address field is required.")]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required(ErrorMessage="Password field is required")]
        [MinLength(8, ErrorMessage="Password be more than 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
