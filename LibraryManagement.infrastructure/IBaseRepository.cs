using System.Linq.Expressions;



namespace LibraryManagement.Infrastructure;

public interface IBaseRepository<T> where T :class
{
    Task<List<T>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<T> GetByIdAsync(int id, CancellationToken token);
    Task AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task RemoveAsync(T entity, CancellationToken token);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken token);

}
