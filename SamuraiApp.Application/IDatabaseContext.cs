using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Application;

public interface IDatabaseContext
{
    DbSet<Quote> Quotes { get; }
    DbSet<Samurai> Samurais { get; }

    void Save();

}