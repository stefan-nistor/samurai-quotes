namespace SamuraiApp.Domain;

public class Quote
{
    public Quote(string text)
    {
        Id = Guid.NewGuid();
        Text = text;
    }
    
    public Guid Id { get; private set; }
    public string Text { get; private set; }
    public Guid SamuraiId { get; private set; }

    public void AttachQuoteToSamurai(Samurai samurai)
    {
        SamuraiId = samurai.Id;
    }
}