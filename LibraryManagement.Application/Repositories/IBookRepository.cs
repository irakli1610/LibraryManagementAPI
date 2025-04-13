using LibraryManagement.Domain.Books;
using System.Linq.Expressions;

namespace LibraryManagement.Application.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<Book> GetByIdAsync(int id, CancellationToken token);
    Task<List<Book>> GetAllFilteredAsync(string title, string author, CancellationToken token);
    Task AddAsync(Book entity, CancellationToken token);
    Task RemoveAsync(Book book, CancellationToken token);
    Task UpdateAsync(Book book, CancellationToken token);
    Task<bool> ExistsAsync(Expression<Func<Book, bool>> predicate, CancellationToken token);
}
