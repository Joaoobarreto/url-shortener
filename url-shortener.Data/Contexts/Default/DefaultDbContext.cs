using Microsoft.EntityFrameworkCore;
using url_shortener.Data.Contexts.Default.Mappings;
using url_shortener.Domain.Entities;

namespace url_shortener.Data.Contexts.Default;
public sealed class DefaultDbContext(DbContextOptions<DefaultDbContext> options) : DbContext(options)
{
    public DbSet<Link> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LinkMapping());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\mylocaldb;Initial Catalog=master;Integrated Security=True");
    }
}
