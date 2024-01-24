using CustomerPurchaseRecord.DataService.Data;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using CustomerPurchaseRecord.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerPurchaseRecord.DataService.Repositories;

public class TransactionDetailRepository : BaseRepository<TransactionDetails>, ITransactionDetailRepository
{
    public TransactionDetailRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
    }

    public override async Task<IEnumerable<TransactionDetails>> GetAll()
    {
        try
        {
            return await _dbSet.OrderBy(t => t.CreatedDate).ToListAsync();
        }
        catch (Exception e) 
        {
            _logger.LogError(e, "{Repo} Get All function error", typeof(CustomerRepository));
            throw;
        }
    }
}
