using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.BorrowRecords;
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.BorrowRecords;

public class BorrowRecordRepository : BaseRepository<BorrowRecord>, IBorrowRecordRepository
{
    public BorrowRecordRepository(LibraryManagementContext context) : base(context)
    {
        
    }
    public async Task<List<BorrowRecord>> GetAllAsyncSearch(int pageNumber, int pageSize, int? bookId, int? patronId, DateTime? borrowDate, DateTime? dueDate, CancellationToken token)
    {
        //add paging
        var records =  await _context.BorrowRecords
            .Where(b => (!bookId.HasValue || b.BookId == bookId) &&
                        (!patronId.HasValue || b.PatronId == patronId) &&
                        (!borrowDate.HasValue || b.BorrowDate >= borrowDate) &&
                        (!dueDate.HasValue || b.DueDate <= dueDate))
            .ToListAsync(token);
        return records;
    }

    public async  Task<List<Book>> GetAllOverdueBooksAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        var currentDateTime = DateTime.Now;

        var overdueBooks = await _context.BorrowRecords
        .Where(b =>b.BookId.HasValue && b.DueDate < currentDateTime && b.ReturnDate == null) 
        .Include(b => b.Book)
        .Skip((pageNumber - 1) * pageSize) 
        .Take(pageSize) 
        .Select(b => b.Book)
        .ToListAsync(token);

        return overdueBooks;
    }
}
