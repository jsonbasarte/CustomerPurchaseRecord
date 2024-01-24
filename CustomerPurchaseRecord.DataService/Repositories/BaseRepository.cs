using CustomerPurchaseRecord.DataService.Data;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerPurchaseRecord.DataService.Repositories;

public class BaseRepository<T> : IBaseRepositories<T> where T : class
{
    public readonly ILogger _logger;
    private readonly AppDbContext _dbContext;
    internal DbSet<T> _dbSet;

    public BaseRepository(AppDbContext dbContext, ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        _dbSet = dbContext.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
