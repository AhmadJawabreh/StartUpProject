using Microsoft.EntityFrameworkCore;

using Entities;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
            .HasOne<Publisher>(item => item.Publisher)
            .WithMany(item => item.Books)
            .HasForeignKey(item => item.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AutherBook>()
                .HasKey(item => new { item.AutherId, item.BookId });

             modelBuilder.Entity<AutherBook>()
            .HasOne<Auther>(item => item.Auther)
            .WithMany(item => item.Books)
            .HasForeignKey(item => item.AutherId);


            modelBuilder.Entity<AutherBook>()
                .HasOne<Book>(item => item.Book)
                .WithMany(item => item.Authers)
                .HasForeignKey(item => item.BookId);

        }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Auther> Authers { get; set; }

        public DbSet<AutherBook> AutherBook { get; set; }
    }
}
