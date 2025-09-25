using Microsoft.EntityFrameworkCore;

namespace Learn.Csharp.AsyncAwait.Console
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Application");
        }
    }
}