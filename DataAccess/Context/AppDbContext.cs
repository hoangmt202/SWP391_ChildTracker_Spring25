using System;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options = null) : base(options) { }

        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure BlogEntity
            modelBuilder.Entity<BlogEntity>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Content)
                    .IsRequired();

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500);

                entity.Property(e => e.Views)
                    .HasDefaultValue(0);

                entity.Property(e => e.Likes)
                    .HasDefaultValue(0);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValue("Draft");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

                // Relationship with Users
                entity.HasOne(b => b.Author)
                    .WithMany()
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure UserEntity
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                // Added fields for UserEntity
                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsRequired();

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasDefaultValue(1)  // Giả sử status là 1 (active)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
