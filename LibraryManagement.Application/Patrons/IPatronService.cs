using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Patrons.Models;
namespace LibraryManagement.Application.Patrons;

public interface IPatronService
{
    Task<List<PatronResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<PatronResponseModel> GetByIdAsync(int id, CancellationToken token);
    Task<List<BookResponseModel>> GetAllBooksByPatronId(int id, CancellationToken token);
    Task AddAsync(PatronRequestModel model, CancellationToken token);
    Task UpdateAsync(int id, PatronRequestModel model, CancellationToken token);
    Task RemoveAsync(int id, CancellationToken token);        
}
