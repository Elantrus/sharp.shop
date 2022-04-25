namespace Core.Exceptions;

public class PasswordIsTooWeakException : Exception
{

    public PasswordIsTooWeakException(string weakMessage) : base($"Provided password is too weak. It should contains at least one {weakMessage}")
    {
        
    }
}