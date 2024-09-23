using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL1
{
    // DAL1/ApplicationDbContext.cs

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Batch> Batches { get; set; }
    }

}
