using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.Books;
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Authors;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryManagementContext context) : base (context)
    {
        
    }

    public async Task<List<Book>> GetAllBooksByAuthor(int id, CancellationToken token)
    {
        return await _context.Books
        .Where(b => b.AuthorId == id)
        .ToListAsync(token);
    }
}
