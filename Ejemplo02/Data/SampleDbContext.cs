using Ejemplo02.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo02.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) 
            : base(options)
        {            
        }

        public DbSet<User> Users { get; set; }
    }
}
