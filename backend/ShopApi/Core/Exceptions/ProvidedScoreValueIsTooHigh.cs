namespace Core.Exceptions;

public class ProvidedScoreValueIsTooHigh : Exception
{
    public ProvidedScoreValueIsTooHigh(int score) : base($"Provided score {score} is too high.")
    {
            
    }
}