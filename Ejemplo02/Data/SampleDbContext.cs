using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Ejemplo02.Data
{
    public class SampleDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
            
        }
    }
}
