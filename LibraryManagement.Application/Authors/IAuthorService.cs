using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Authors
{
    public interface IAuthorService
    {
        Task<List<AuthorResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<AuthorResponseModel> GetByIdAsync(int id, CancellationToken token);
        Task<List<BookResponseModel>> GetAllBooksByAuthor(int id, CancellationToken token);
        Task AddAsync(AuthorRequestModel model, CancellationToken token);
        Task UpdateAsync(int id, AuthorRequestModel model, CancellationToken token);
        Task RemoveAsync(int id, CancellationToken token);
        
    }
}
