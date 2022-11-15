using SamuraiApp.Domain.Helpers;

namespace SamuraiApp.Domain;

public class Samurai
{
    public Samurai(string name)
    {
        
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<Quote> Quotes { get; private set; }

    public Result RegisterQuetesToSamurai(List<Quote> quotes)
    {
        if (!quotes.Any())
        {
            return Result.Failure("Add at least one quote for the current Samurai");
        }
        
        quotes.ForEach(q =>
        {
            q.AttachQuoteToSamurai(this);
            Quotes.Add(q);
        });
        return Result.Success();
    }
}