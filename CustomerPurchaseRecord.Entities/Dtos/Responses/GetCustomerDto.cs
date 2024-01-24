namespace CustomerPurchaseRecord.Entities.Dtos.Responses;

public class GetCustomerDto
{
    public int CustomerId { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
