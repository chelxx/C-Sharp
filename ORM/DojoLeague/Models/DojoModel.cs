using System.ComponentModel.DataAnnotations;
namespace DojoLeague.Models
{
    public abstract class BaseEntity 
    {
        // BASE ENTITY IS LEFT EMPTY!!!!
    }
    public class Dojo : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string DojoName { get; set; }

        [Required]
        [MinLength(3)]
        public string DojoLocation { get; set; }

        [MinLength(3)]
        public string DojoInfo { get; set; }
    }
}