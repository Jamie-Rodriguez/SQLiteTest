using Microsoft.EntityFrameworkCore;

namespace SQLiteTest
{
    class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key
            modelBuilder.Entity<Blog>()
                .HasKey(b => new { b.BlogId, b.Published });

            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Url)
                .IsUnique()
                .HasName("Index_Url");
        }
    }
}
