using SamuraiApp.Domain;

namespace SamuraiApp.Application.Repositories;

public interface IQuoteRepository
{
    void Add(Quote quote);
    List<Quote> GetAll();
    Quote Get(Guid id);
    void Delete(Quote quote);
    void Save();
}

public class QuoteRepository : IQuoteRepository
{
    private readonly IDatabaseContext context;
    
    public QuoteRepository(IDatabaseContext context)
    {
        this.context = context;
    }

    public void Add(Quote quote)
    {
        context.Quotes.Add(quote);
    }

    public List<Quote> GetAll()
    {
        return context.Quotes.ToList();
    }
    
    public Quote Get(Guid id)
    {
        return context.Quotes.Find(id);
    }

    public void Delete(Quote quote)
    { 
        context.Quotes.Remove(quote);
    }

    public void Save()
    {
        context.Save(); 
    }
    
}