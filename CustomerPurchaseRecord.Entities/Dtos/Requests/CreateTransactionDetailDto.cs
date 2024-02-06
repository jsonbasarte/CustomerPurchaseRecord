using System.ComponentModel.DataAnnotations;

namespace CustomerPurchaseRecord.Entities.Dtos.Requests;

public class CreateTransactionDetailDto
{
    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Qty { get; set; }

    [Required]
    public int CustomerId { get; set; }
}
