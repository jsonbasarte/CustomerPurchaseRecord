using CustomerPurchaseRecord.DataService.Data;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using CustomerPurchaseRecord.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerPurchaseRecord.DataService.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
    }

    public override async Task<IEnumerable<Customer>> GetAll()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception e) 
        {
            _logger.LogError(e, "{Repo} Get All function error", typeof(CustomerRepository));
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> SearchByCustomerName(string customerName)
    {
        try
        {

            if (customerName == null)
            {
                return await _dbSet.ToListAsync();
            }

            var result = await _dbSet
                .Where(c => c.FirstName.StartsWith(customerName))
                .ToListAsync();

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} SearchByCustomerName function error", typeof(CustomerRepository));
            throw;
        }
    }
}
