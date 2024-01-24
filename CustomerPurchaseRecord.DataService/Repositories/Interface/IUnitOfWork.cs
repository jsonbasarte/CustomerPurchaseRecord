namespace CustomerPurchaseRecord.DataService.Repositories.Interface;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }
    ITransactionDetailRepository TransactionDetails { get; }
    Task<bool> SaveAsync();
}
