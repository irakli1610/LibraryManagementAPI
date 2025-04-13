using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.BorrowRecords;
using System.Linq.Expressions;

namespace LibraryManagement.Application.Repositories;

public interface IBorrowRecordRepository
{
    Task<BorrowRecord> GetByIdAsync(int id, CancellationToken token);
    Task AddAsync(BorrowRecord entity, CancellationToken token);
    Task UpdateAsync(BorrowRecord record, CancellationToken token);
    Task<List<BorrowRecord>> GetAllAsyncSearch(int pageNumber, int pageSize, int? bookId, int? patronId, DateTime? borrowDate, DateTime? dueDate, CancellationToken token);
    Task<List<Book>> GetAllOverdueBooksAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<bool> ExistsAsync(Expression<Func<BorrowRecord, bool>> predicate, CancellationToken token);
}
