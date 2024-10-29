using Microsoft.EntityFrameworkCore;

namespace MathDb
{
    public class MathDbContext:DbContext
    {
        public MathDbContext(DbContextOptions<MathDbContext> options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
