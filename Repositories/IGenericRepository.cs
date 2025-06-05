// Student ID: 00013630
using System.Linq.Expressions;

namespace BakeryApi.Repositories;

public interface IGenericRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T?> GetByIdAsync(int id);
	Task<T> AddAsync(T entity);
	Task<T> UpdateAsync(T entity);
	Task<bool> DeleteAsync(int id);
}

