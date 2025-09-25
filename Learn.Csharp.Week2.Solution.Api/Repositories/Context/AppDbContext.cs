using Learn.Csharp.Week2.Solution.Api.Domain;
using Learn.Csharp.Week2.Solution.Api.Domain.Mapping;
using Learn.Csharp.Week2.Solution.Api.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Learn.Csharp.Week2.Solution.Api.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> UsersRepository { get; set; }
        public DbSet<Blog> BlogsRepository { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new BlogMapping());
        }
    }
}
