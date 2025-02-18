
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<BlogEntity> Blogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogEntity>().HasKey(b => b.BlogId);
        }
    }
}
