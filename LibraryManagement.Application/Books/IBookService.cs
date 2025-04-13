using LibraryManagement.Application.Books.Models;

namespace LibraryManagement.Application.Books;

public interface IBookService
{
    Task<List<BookResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<BookResponseModel> GetByIdAsync(int id, CancellationToken token);
    Task<List<BookResponseModel>> GetAllFilteredAsync(string title, string author, CancellationToken token);
    Task AddAsync(BookRequestModel model, CancellationToken token);
    Task UpdateAsync(int id, BookRequestModel model, CancellationToken token);
    Task DeleteAsync(int id, CancellationToken token);
    Task<bool> IsBookAvailableForBorrowing(int id, CancellationToken token);
}
