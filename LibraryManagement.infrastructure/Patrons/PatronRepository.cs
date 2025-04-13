using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.Patrons;
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Patrons;

public class PatronRepository : BaseRepository<Patron>, IPatronRepository
{
    public PatronRepository(LibraryManagementContext context) : base(context)
    {
    }
    public async Task<List<Book>> GetAllBooksByPatronId(int id, CancellationToken token)
    {
        var books = await _dbSet
         .Include(p => p.BorrowRecords)
         .ThenInclude(br => br.Book)
         .Where(p => p.Id == id)
         .SelectMany(p => p.BorrowRecords
             .Where(br => br.ReturnDate == null)
             .Select(br => br.Book))
         .ToListAsync(token);

        return books;
    }
}