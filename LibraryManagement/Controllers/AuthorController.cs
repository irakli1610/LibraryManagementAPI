using Asp.Versioning;
using LibraryManagement.API.Models.Examples.Author;
using LibraryManagement.API.Models.Examples.Books;
using LibraryManagement.Application.Authors;
using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion(1)]
    [ApiVersion(2)]
    [Produces("application/json")]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Get all authors with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, "Successfully retrieved Authors")]
        [SwaggerRequestExample(typeof(AuthorRequestModel), typeof(AuthorsResponseModelExample))]
        public async Task<List<AuthorResponseModel>> GetAllAsync(int pageNumber, int pageSize,CancellationToken token)
        {
            return await _authorService.GetAllAsync(pageNumber, pageSize, token);
        }

        /// <summary>
        /// Get a specific author by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Successfully retrieved Author")]
        [SwaggerResponse(404, "Author Not found")]
        [SwaggerRequestExample(typeof(AuthorRequestModel), typeof(AuthorResponseModelExample))]
        public async Task<ActionResult<AuthorResponseModel>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _authorService.GetByIdAsync(id, token);
        }

        /// <summary>
        /// Get all books by a specific author 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/books")]
        [SwaggerResponse(200, "Successfully retrieved Author")]
        [SwaggerResponse(404, "Author Not found")]
        public async Task<List<BookResponseModel>> GetAllBooksByAuthor([FromRoute] int id, CancellationToken token)
        {
            return await _authorService.GetAllBooksByAuthor(id, token);
        }

        /// <summary>
        /// Add a new author 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(200, "Successfully created Author")]
        [SwaggerRequestExample(typeof(AuthorRequestModel),typeof(AuthorsRequestModelExample))]
        public async Task AddAsync([FromBody] AuthorRequestModel model, CancellationToken token)
        {           
            await _authorService.AddAsync(model, token);
        }

        /// <summary>
        /// Update an existing author
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="token"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        [SwaggerResponse(200, "Successfully updated Author")]
        [SwaggerResponse(404, "Author Not found")]
        [SwaggerRequestExample(typeof(AuthorRequestModel), typeof(AuthorsRequestModelExample))]
        public async Task UpdateAsync([FromRoute] int id, [FromBody] AuthorRequestModel model, CancellationToken token)
        {
            await _authorService.UpdateAsync(id, model, token);
        }

        /// <summary>
        /// Delete an author 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Successfully deleted Author")]
        [SwaggerResponse(404, "Author Not found")]
        public async Task DeleteAsync(int id,CancellationToken token)
        {
            await _authorService.RemoveAsync(id, token);
        }

    }
}
