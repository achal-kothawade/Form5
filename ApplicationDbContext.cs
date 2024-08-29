using Form5.Models;
using Microsoft.EntityFrameworkCore;

namespace Form5.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Safety> Safety { get; set; }
    }
}

