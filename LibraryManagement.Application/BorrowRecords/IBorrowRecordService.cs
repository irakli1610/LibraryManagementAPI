using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.BorrowRecords.Models;

namespace LibraryManagement.Application.BorrowRecords;

public interface IBorrowRecordService
{
    Task<List<BorrowRecordResponseModel>> GetAllAsyncSearch(int pageNumber, int pageSize, int? bookId, int? patronId, DateTime? borrowDate, DateTime? dueDate, CancellationToken token);
    Task<BorrowRecordResponseModel> GetByIdAsync(int id, CancellationToken token);
    Task AddAsync(BorrowRecordRequestModel borrowRecordRequestModel, CancellationToken token);
    Task ReturnBook(int id, CancellationToken token);
    Task<List<BookResponseModel>> GetAllOverdueBooksAsync(int pageNumber, int pageSize, CancellationToken token);
    
    
}
