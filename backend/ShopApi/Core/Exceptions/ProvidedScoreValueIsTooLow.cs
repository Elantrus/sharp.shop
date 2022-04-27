namespace Core.Exceptions;

public class ProvidedScoreValueIsTooLow : Exception
{
    public ProvidedScoreValueIsTooLow(int score) : base($"Provided score {score} is too low.")
    {
            
    }
}