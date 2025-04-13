using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Application.Patrons.Models;
using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Patrons;
using Mapster;

namespace LibraryManagement.Application.Patrons;

public class PatronService : IPatronService
{
    private readonly IPatronRepository _repository;

    public PatronService(IPatronRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PatronResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await _repository.GetAllAsync(pageNumber, pageSize, token);
        return result.Adapt<List<PatronResponseModel>>();
    }

    public async Task<PatronResponseModel> GetByIdAsync(int id, CancellationToken token)
    {
        var patronById = await _repository.GetByIdAsync(id, token);

        if (patronById == null)
        {
            throw new NotFoundException(AppExceptions.PatronNotFound);
        }

        return patronById.Adapt<PatronResponseModel>();
    }

    public async Task<List<BookResponseModel>> GetAllBooksByPatronId(int id, CancellationToken token)
    {
        var patronexists = await _repository.ExistsAsync(x => x.Id == id, token);
        if (!patronexists)
        {
            throw new NotFoundException(AppExceptions.PatronNotFound);
        }
        var booksByPatronId = await _repository.GetAllBooksByPatronId(id, token);
        return booksByPatronId.Adapt<List<BookResponseModel>>();
    }

    public async Task AddAsync(PatronRequestModel model, CancellationToken token)
    {
        var patron = model.Adapt<Patron>();
        await _repository.AddAsync(patron, token);
    }
    public async Task UpdateAsync(int id, PatronRequestModel model, CancellationToken token)
    {
        bool exists = await _repository.ExistsAsync(x => x.Id == id, token);
        if (!exists)
        {
            throw new NotFoundException(AppExceptions.PatronNotFound);
        }

        var patron = model.Adapt<Patron>();
        patron.Id = id;

        await _repository.UpdateAsync(patron, token);
    }

    public async Task RemoveAsync(int id, CancellationToken token)
    {
        var patron = await _repository.GetByIdAsync(id, token);
        if(patron == null)
        {
            throw new NotFoundException(AppExceptions.PatronNotFound);
        }

        await _repository.RemoveAsync(patron,token);
    }    
}
