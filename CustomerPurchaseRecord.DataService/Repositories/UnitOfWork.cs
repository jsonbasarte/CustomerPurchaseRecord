using CustomerPurchaseRecord.DataService.Data;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using Microsoft.Extensions.Logging;

namespace CustomerPurchaseRecord.DataService.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public ICustomerRepository Customers { get; }
    public ITransactionDetailRepository TransactionDetails { get; }

    public UnitOfWork(AppDbContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;

        var logger = loggerFactory.CreateLogger("logs");

        Customers = new CustomerRepository(dbContext, logger);

        TransactionDetails = new TransactionDetailRepository(dbContext, logger);
    }

    public async Task<bool> SaveAsync()
    {
        var result = await _dbContext.SaveChangesAsync();

        return result > 0;
    }
}
