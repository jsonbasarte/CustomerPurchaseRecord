namespace CustomerPurchaseRecord.Entities.Dtos.Requests;

public class CreateTransactionDetailDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public int CustomerId { get; set; }
}
