using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Product
{
    public long Id { get; set; }
    public string Description { get; set; }
    public double SalePrice { get; set; }
    public double ProductCost { get; set; }
    public virtual Metric Metric { get; set; }
}