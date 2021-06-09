using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasOne<Publisher>(item => item.Publisher)
            .WithMany(item => item.Books)
            .HasForeignKey(item => item.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>().HasIndex(item => item.Name).IsUnique(true);
        }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
