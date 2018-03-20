using Microsoft.EntityFrameworkCore;

namespace EntityBlank.Models
{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<ModelName> DB_TABLE_NAME_HERE {get;set;}
    }
}