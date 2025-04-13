using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.Patrons;
using System.Linq.Expressions;

namespace LibraryManagement.Application.Repositories;

public interface IPatronRepository
{
    Task<List<Patron>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<Patron> GetByIdAsync(int id, CancellationToken token);
    Task<List<Book>> GetAllBooksByPatronId(int id,CancellationToken token);
    Task AddAsync(Patron patron, CancellationToken token);
    Task UpdateAsync(Patron patron, CancellationToken token);
    Task RemoveAsync(Patron patron,CancellationToken token);
    Task<bool> ExistsAsync(Expression<Func<Patron, bool>> predicate, CancellationToken token);
}
