using System.ComponentModel.DataAnnotations;
namespace DojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string NinjaName { get; set; }

        [Required]
        public string NinjaLevel { get; set; }

        [Required]
        [MinLength(3)]
        public string NinjaDescription { get; set; }

        public int dojos_Id { get; set; }
        public string DojoName{get;set;}
    }
}