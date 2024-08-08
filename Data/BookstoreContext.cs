using Microsoft.EntityFrameworkCore;
using BookstoreAPI.Models;
using System.Collections.Generic;

namespace BookstoreAPI.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.book_id);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.author_id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.genre_id);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.author_id);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.genre_id);
        }
    }
}