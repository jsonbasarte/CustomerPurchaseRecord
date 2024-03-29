﻿namespace CustomerPurchaseRecord.DataService.Repositories.Interface;

public interface IBaseRepositories<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
    Task<IEnumerable<T>> GetCustomerTransaction(int customerId);
}
