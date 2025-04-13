using Asp.Versioning;
using LibraryManagement.API.Models.Examples.Author;
using LibraryManagement.API.Models.Examples.Books;
using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion(1)]
    [ApiVersion(2)]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;
        public BookController(IBookService service) 
        {
            _bookService = service;
        }


        /// <summary>
        /// Get all books with pagination support 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, "Successfully retrieved Books")]
        [SwaggerRequestExample(typeof(BookRequestModel), typeof(BooksResponseModelExample))]
        public async Task<List<BookResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token)
        {
            return await _bookService.GetAllAsync(pageNumber, pageSize, token);
        }

        /// <summary>
        /// Get a specific book by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Successfully retrieved Patron")]
        [SwaggerResponse(404, "Book Not found")]
        [SwaggerRequestExample(typeof(BookRequestModel), typeof(BookResponseModelExample))]
        public async Task<BookResponseModel> GetByIdAsync(int id, CancellationToken token)
        {
            return await _bookService.GetByIdAsync(id, token);
        }

        /// <summary>
        /// Search books by title or author
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        [SwaggerResponse(200, "Successfully deleted Books by specific Author")]
        [SwaggerRequestExample(typeof(BookRequestModel), typeof(BooksResponseModelExample))]
        public async Task<List<BookResponseModel>> GetAllFilteredAsync([FromQuery] string? title, [FromQuery] string? author, CancellationToken token)
        {
            return await _bookService.GetAllFilteredAsync(title, author, token);
        }

        /// <summary>
        /// Add a new book 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(200, "Successfully created Book")]
        [SwaggerRequestExample(typeof(BookRequestModel), typeof(BooksRequestModelExample))]
        public async Task AddAsync([FromBody] BookRequestModel model, CancellationToken token)
        {
            await _bookService.AddAsync(model, token);
        }

        /// <summary>
        /// Update an existing book 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerResponse(200, "Successfully updated book")]
        [SwaggerResponse(404, "book Not found")]
        [SwaggerResponse(409, "conflict while updating book")]
        [SwaggerRequestExample(typeof(BookRequestModel), typeof(BooksRequestModelExample))]
        public async Task UpdateAsync([FromRoute] int id, [FromBody] BookRequestModel model, CancellationToken token)
        {
            await _bookService.UpdateAsync(id, model, token);
        }

        /// <summary>
        /// Delete a book 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Successfully deleted book")]
        [SwaggerResponse(404, "book Not found")]
        public async Task DeleteAsync([FromRoute] int id, CancellationToken token)
        {
            await _bookService.DeleteAsync(id, token);
        }

        /// <summary>
        /// Check if a book is available for borrowing
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/availability")]
        [SwaggerResponse(200, "Successfully retrieved if book is available")]
        [SwaggerResponse(404, "book Not found")]
        public async Task<bool> IsBookAvailableForBorrowing([FromRoute] int id, CancellationToken token)
        {
            return await _bookService.IsBookAvailableForBorrowing(id, token);
        }
    }
}
