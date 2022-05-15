using Microsoft.EntityFrameworkCore;
using ErrataManager.Models;

namespace ErrataManager.Data;
public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Error>()
            .HasOne<Book>()
            .WithMany()
            .HasForeignKey(p => p.BookId)
            .HasPrincipalKey(p => p.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Book>().HasData(
        new Book
        {
           Name="Seed",
           Id=2
        }
    );
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Error> Errors => Set<Error>();
}


