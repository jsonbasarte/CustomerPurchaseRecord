namespace CustomerPurchaseRecord.Entities.DbSet;

public class TransactionDetails : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
}
