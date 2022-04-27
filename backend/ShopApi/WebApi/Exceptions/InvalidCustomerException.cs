namespace WebApi.Exceptions;

public class InvalidCustomerException : Exception
{
    public InvalidCustomerException() : base($"Customer not found.")
    {
        
    }
}