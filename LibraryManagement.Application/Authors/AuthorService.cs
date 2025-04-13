using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.Authors;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAsync(pageNumber, pageSize, cancellationToken);
            return authors.Adapt<List<AuthorResponseModel>>();
        }

        public async Task<AuthorResponseModel> GetByIdAsync(int id, CancellationToken token)
        {
            var author = await _authorRepository.GetByIdAsync(id, token);

            if (author == null)
            {
                throw new NotFoundException(AppExceptions.AuthorNotFound);
            }

            return author.Adapt<AuthorResponseModel>();
        }

        public async Task<List<BookResponseModel>> GetAllBooksByAuthor(int id, CancellationToken token)
        {
            var authorExists = await _authorRepository.ExistsAsync(x => x.Id == id, token);
            if(!authorExists){
                throw new NotFoundException(AppExceptions.AuthorNotFound);
            }
            var books =  await _authorRepository.GetAllBooksByAuthor(id, token);

            return books.Adapt<List<BookResponseModel>>();
        }

        public async Task AddAsync(AuthorRequestModel model, CancellationToken token)
        {
            var author = model.Adapt<Author>();
            await _authorRepository.AddAsync(author, token);
        }

        public async Task UpdateAsync(int id, AuthorRequestModel model, CancellationToken token)
        {
            bool exists = await _authorRepository.ExistsAsync(x => x.Id == id, token);
            if (!exists)
            {
                throw new NotFoundException(AppExceptions.AuthorNotFound);
            }
            var author = model.Adapt<Author>();
            author.Id = id;

            await _authorRepository.UpdateAsync(author, token);
        }

        public async Task RemoveAsync(int id, CancellationToken token)
        {
            var author = await _authorRepository.GetByIdAsync(id, token);
            if(author == null)
            {
                throw new NotFoundException(AppExceptions.AuthorNotFound);
            }

            await _authorRepository.RemoveAsync(author, token);
        }
    
    }
}
