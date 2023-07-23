using BookWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Books> Books{ get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<Shop> Shops { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Author)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books) 
                .HasForeignKey(b => b.GenreId); 

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Shop) 
                .WithMany(s => s.Books) 
                .HasForeignKey(b => b.ShopId);

        }

    }
}
