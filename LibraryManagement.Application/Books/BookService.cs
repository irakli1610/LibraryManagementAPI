using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Books;
using Mapster;

namespace LibraryManagement.Application.Books;

public class BookService : IBookService
{
    public readonly IBookRepository _repository;

	public BookService(IBookRepository repository)
	{
		_repository = repository;
	}

    public async Task<List<BookResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(pageNumber, pageSize, cancellationToken);

        return result.Adapt<List<BookResponseModel>>();
    }

    public async Task<BookResponseModel> GetByIdAsync(int id, CancellationToken token)
    {
        var bookById = await _repository.ExistsAsync(x => x.Id == id, token);

        if (!bookById)
        {
            throw new NotFoundException(AppExceptions.BookNotFound);
        }

        return bookById.Adapt<BookResponseModel>();
    }

    public async Task<List<BookResponseModel>> GetAllFilteredAsync(string title, string author, CancellationToken token)
    {
        var filteredBooks = await _repository.GetAllFilteredAsync(title, author, token);
        return filteredBooks.Adapt<List<BookResponseModel>>();
    }

    public async Task AddAsync(BookRequestModel model, CancellationToken token)
    {
        var book = model.Adapt<Book>();

        await _repository.AddAsync(book, token);
    }

    public async Task UpdateAsync(int id, BookRequestModel model, CancellationToken token)
    {
        bool bookExists = await _repository.ExistsAsync(b => b.Id == id, token);
        if (!bookExists)
        {
            throw new NotFoundException(AppExceptions.BookNotFound);
        }

        var book = model.Adapt<Book>();
        book.Id = id;
        await _repository.UpdateAsync(book, token);
    }

    public async Task DeleteAsync(int id, CancellationToken token)
    {
        var book = await _repository.GetByIdAsync(id, token);

        if(book == null)
        {
            throw new NotFoundException(AppExceptions.BookNotFound);
        }

        await _repository.RemoveAsync(book, token);
    }

    public async Task<bool> IsBookAvailableForBorrowing(int id, CancellationToken token)
    {
        var bookById = await _repository.GetByIdAsync(id, token);

        if (bookById == null)
        {
            throw new NotFoundException(AppExceptions.BookNotFound);
        }

        return bookById.Quantity >= 1;
    }
}
