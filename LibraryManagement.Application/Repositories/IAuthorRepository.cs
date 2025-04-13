using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.Books;
using System.Linq.Expressions;

namespace LibraryManagement.Application.Repositories;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<Author> GetByIdAsync(int id, CancellationToken token);
    Task AddAsync(Author entity, CancellationToken token);
    Task RemoveAsync(Author author, CancellationToken token);
    Task<List<Book>> GetAllBooksByAuthor(int id, CancellationToken token);
    Task UpdateAsync(Author author, CancellationToken token);
    Task<bool> ExistsAsync(Expression<Func<Author, bool>> predicate, CancellationToken token);
}
