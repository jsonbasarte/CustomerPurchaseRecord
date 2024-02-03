using CustomerPurchaseRecord.Entities.DbSet;

namespace CustomerPurchaseRecord.DataService.Repositories.Interface;

public interface ICustomerRepository : IBaseRepositories<Customer>
{
    Task<IEnumerable<Customer>> SearchByCustomerName(string customerName);
}
