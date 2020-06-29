using Microsoft.EntityFrameworkCore;

namespace ProductSearch.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
    }
}