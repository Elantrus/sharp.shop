namespace WebApi.Exceptions;

public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException() : base($"Provided E-mail already exists.")
    {
            
    }
}