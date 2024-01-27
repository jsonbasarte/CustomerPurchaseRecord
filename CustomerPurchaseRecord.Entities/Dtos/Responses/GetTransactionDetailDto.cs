namespace CustomerPurchaseRecord.Entities.Dtos.Responses;

public class GetTransactionDetailDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CustomerId { get; set; }
}
