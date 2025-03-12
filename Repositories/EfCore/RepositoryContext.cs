using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kitap - Yazar ilişkisi: Bir kitap bir yazara ait olabilir
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)  // Kitap ile Yazar arasında bir ilişki olduğunu belirtir
                .WithMany(a => a.Books) // Yazarın birden fazla kitabı olabilir
                .HasForeignKey(b => b.AuthorID) // Kitap tablosundaki AuthorId alanını, Author tablosunun Id'sine bağlar
                .OnDelete(DeleteBehavior.Restrict); // Silme davranışı: Kitap silinemez, yazar silindiğinde kitap silinmez


            // Kitap - Tür (KitapGenres) ilişkisi: Kitap ve Tür arasında çoktan çoğa bir ilişki
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookID, bg.GenreID });  // Bir kitap ve bir tür arasındaki ilişkinin birincil anahtarını belirtir

            modelBuilder.Entity<BookGenre>()
               .HasOne(bg => bg.Book)  // BookGenre ile Book arasında ilişki
               .WithMany(b => b.BookGenres)  // Bir kitabın birden fazla türü olabilir
               .HasForeignKey(bg => bg.BookID)  // BookGenres tablosundaki BookId, Books tablosundaki Id'ye bağlanır
               .OnDelete(DeleteBehavior.Cascade);  // Kitap silindiğinde, ilgili BookGenres kayıtları da silinir

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)  // BookGenre ile Genre arasında ilişki
                .WithMany(g => g.BookGenres)  // Bir türün birden fazla kitabı olabilir
                .HasForeignKey(bg => bg.GenreID)  // BookGenres tablosundaki GenreId, Genres tablosundaki Id'ye bağlanır
                .OnDelete(DeleteBehavior.Cascade);  // Tür silindiğinde, ilgili BookGenres kayıtları da silinir

            base.OnModelCreating(modelBuilder);
        }
    }
}
