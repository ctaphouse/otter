using Microsoft.EntityFrameworkCore;
using otter.api.Persistence.Entities;

namespace otter.api.Persistence;

public class OtterContext : DbContext
{
    public OtterContext(DbContextOptions<OtterContext> options) : base(options)
    {
        
    }

    public DbSet<Book>? Books { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Library>? Libraries { get; set; }
}