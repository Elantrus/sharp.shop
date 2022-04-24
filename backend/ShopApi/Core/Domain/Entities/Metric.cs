namespace Core.Domain.Entities;

public class Metric
{
    public long Id { get; set; }
    public long TotalSales { get; set; }
    public double Score { get; set; }
    public double GrossValue { get; set; }
    public double NetValue { get; set; }
    public virtual Product Product { get; set; }
    public long ProductForeignId { get; set; }
}