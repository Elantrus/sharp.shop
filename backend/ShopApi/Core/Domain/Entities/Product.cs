namespace Core.Domain.Entities;

public class Product
{
    public long Id { get; protected set; }
    public string Description { get; set; }
    public double SalePrice { get; set; }
    public double ProductCost { get; set; }
    public virtual Metrics Metrics { get; set; }
}