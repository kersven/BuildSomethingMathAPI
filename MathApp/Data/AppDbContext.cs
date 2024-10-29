using Microsoft.EntityFrameworkCore;

namespace MathApp.Services
{
    public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<RequestLog> RequestLogs { get; set; }
        }
    }
    