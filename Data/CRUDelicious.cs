using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Data
{
    public class DeliciousContext : DbContext
    {
        public DeliciousContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Dishe> Dishes { get; set; }
    }
}
