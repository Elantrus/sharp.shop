using Core.Exceptions;

namespace Core.Domain.Entities;

public class Review
{
    public long Id { get; set; }
    public int Score { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public Customer Customer { get; set; }
    
    public Product Product { get; set; }

    public Review()
    {
    }

    public Review(int score, string description, string title)
    {
        Description = description;
        Title = title;
        SetScore(score);
    }

    private void SetScore(int score)
    {
        if (score > 5) throw new ProvidedScoreValueIsTooHigh(score);
        if (score <= 0) throw new ProvidedScoreValueIsTooLow(score);
        Score = score;
    }
}