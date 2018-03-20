using System;
using System.ComponentModel.DataAnnotations;

namespace EntityBlank.Models
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
    public class ModelName : BaseEntity
    {
        // These must match your column in your table database!
        [Key]
        public int SpecificID {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Must be filled out!")]
        public string TableColumn {get;set;}
    }
}