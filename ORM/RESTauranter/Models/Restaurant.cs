using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class ValidDateAttribute : ValidationAttribute 
    {
        public override bool IsValid (object value) 
        {
            DateTime d = Convert.ToDateTime (value);
            return d <= DateTime.Now;
        }
    }
    public abstract class BaseEntity
    {
        // EMPTY!!!
    }
    public class Restaurant : BaseEntity
    {
        [Key]
        public int RestaurantID {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Must be filled out!")]
        public string ReviewerName {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Must be filled out!")]
        public string RestaurantName {get;set;}
        [Required]
        [MinLength(10, ErrorMessage="Must be filled out!")]
        public string Review {get;set;}

        [Required]
        [ValidDate(ErrorMessage ="Date can not be in the future!")]
        public DateTime DateVisit {get;set;}

        [Required]
        public int Stars {get;set;}
    }
}