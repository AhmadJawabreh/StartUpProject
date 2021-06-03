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

            modelBuilder.Entity<AuthorBook>()
                .HasKey(item => new { item.AuthorId, item.BookId });

             modelBuilder.Entity<AuthorBook>()
            .HasOne<Author>(item => item.Author)
            .WithMany(item => item.Books)
            .HasForeignKey(item => item.AuthorId);


            modelBuilder.Entity<AuthorBook>()
                .HasOne<Book>(item => item.Book)
                .WithMany(item => item.Authers)
                .HasForeignKey(item => item.BookId);

        }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorBook> AuthorBook { get; set; }
    }
}
