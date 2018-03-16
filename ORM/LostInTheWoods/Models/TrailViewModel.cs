using System.ComponentModel.DataAnnotations;
namespace LostInTheWoods.Models
{
    public abstract class BaseEntity 
    {
        // BASE ENTITY IS LEFT EMPTY!!!!
    }
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string TrailName { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [MinLength(3)]
        public string TrailLength { get; set; }

        [Required]
        [MinLength(3)]
        public string ElevationChange { get; set; }
    }
}
