namespace CustomerPurchaseRecord.Entities.DbSet;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public ICollection<TransactionDetails> TransactionDetails { get; } = new List<TransactionDetails>();
}
