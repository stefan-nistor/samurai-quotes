using Microsoft.EntityFrameworkCore;
using SamuraiApp.Application;
using SamuraiApp.Domain;

namespace SamuraiApp.Infrastructure;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Quote> Quotes => Set<Quote>();
    public DbSet<Samurai> Samurais => Set<Samurai>();
    public void Save()
    {
        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source - SamuraiApp.db");
    }
}