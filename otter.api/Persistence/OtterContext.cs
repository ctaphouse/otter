using Microsoft.EntityFrameworkCore;
using otter.api.Persistence.Entities;

namespace otter.api.Persistence;

public class OtterContext : DbContext
{
    public OtterContext(DbContextOptions<OtterContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<BookLibrary> BookLibrary { get; set; } = default!;
    public DbSet<Library> Libraries { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Book>()
        .HasMany(b => b.Libraries)
        .WithMany(l => l.Books)
        .UsingEntity<BookLibrary>(
            j => j.HasOne(j => j.Library).WithMany().HasForeignKey(j => j.LibraryId),
            j => j.HasOne(j => j.Book).WithMany().HasForeignKey(j => j.BookId));
    }
}