namespace WebApi.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(long productId) : base($"Product {productId} not found.")
    {
            
    }
}