namespace WebApi.Exceptions;

public class PasswordOrEmailIsInvalidException : Exception
{
    public PasswordOrEmailIsInvalidException() : base($"Password or Email is invalid.")
    {
        
    }
    
}