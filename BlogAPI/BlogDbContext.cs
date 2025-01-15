using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<DbContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity => 
            { 
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Content).IsRequired();
                entity.Property(p => p.Author).IsRequired().HasMaxLength(50);
                entity.Property(p => p.UpdatedDate).IsRequired();
            });
        }
    }
}
