using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Books;
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Books
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {

        public BookRepository(LibraryManagementContext context) : base(context)
        {

        }

        public async Task<List<Book>> GetAllFilteredAsync(string title, string author, CancellationToken token)
        {
            return await _context.Books
                .Where(b => (string.IsNullOrEmpty(title) || b.Title.Contains(title)) &&
                            (string.IsNullOrEmpty(author) || (b.Author.FirstName + " " + b.Author.LastName).Contains(author)))
                .ToListAsync(token);
        }
    }
}
