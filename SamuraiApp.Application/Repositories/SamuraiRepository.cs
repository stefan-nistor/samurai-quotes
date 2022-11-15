using SamuraiApp.Domain;

namespace SamuraiApp.Application.Repositories;

public interface ISamuraiRepository
{
    void Add(Samurai samurai);
    List<Samurai> GetAll();
    Samurai Get(Guid id);
    void Delete(Samurai samurai);
    void Save();
}

public class SamuraiRepository : ISamuraiRepository
{
    private readonly IDatabaseContext context;
    
    public SamuraiRepository(IDatabaseContext context)
    {
        this.context = context;
    }

    public void Add(Samurai samurai)
    {
        context.Samurais.Add(samurai);
    }

    public List<Samurai> GetAll()
    {
        return context.Samurais.ToList();
    }

    public Samurai Get(Guid id)
    {
        return context.Samurais.Find(id);
    }

    public void Delete(Samurai samurai)
    {
        context.Samurais.Remove(samurai);
    }

    public void Save()
    {
        context.Save(); 
    }
    
}