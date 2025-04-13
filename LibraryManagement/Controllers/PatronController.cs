using Asp.Versioning;
using LibraryManagement.API.Models.Examples.Books;
using LibraryManagement.API.Models.Examples.Patron;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Patrons;
using LibraryManagement.Application.Patrons.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiVersion(1)]
[ApiVersion(2)]
[Produces("application/json")]
public class PatronController : ControllerBase
{
    private readonly IPatronService _patronService;

    public PatronController(IPatronService service)
    {
        _patronService = service;
    }

    /// <summary>
    /// Get all patrons with pagination
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [SwaggerResponse(200, "Successfully retrieved Patrons")]
    [SwaggerRequestExample(typeof(PatronResponseModel), typeof(PatronsResponseModelExample))]
    public async Task<List<PatronResponseModel>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _patronService.GetAllAsync(pageNumber, pageSize, token);
    }

    /// <summary>
    /// Get a specific patron by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [SwaggerResponse(200, "Successfully retrieved Patron")]
    [SwaggerResponse(404, "Patron Not found")]
    [SwaggerRequestExample(typeof(PatronResponseModel), typeof(PatronResponseModelExample))]
    public async Task<PatronResponseModel> GetByIdAsync(int id, CancellationToken token)
    {
        return await _patronService.GetByIdAsync(id, token);
    }

    /// <summary>
    /// Get all books currently borrowed by a patron 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{id}/books")]
    [SwaggerResponse(200, "Successfully retrieved books by patron")]
    [SwaggerResponse(404, "Patron Not found")]
    [SwaggerRequestExample(typeof(BookResponseModel), typeof(BooksResponseModelExample))]
    public async Task<List<BookResponseModel>> GetAllBooksByPatronId(int id, CancellationToken token)
    {
        return await _patronService.GetAllBooksByPatronId(id, token);
    }

    /// <summary>
    /// Add a new patron 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerResponse(200, "Successfully created Patron")]
    [SwaggerRequestExample(typeof(PatronRequestModel), typeof(PatronsRequestModelExample))]
    public async Task AddAsync([FromBody] PatronRequestModel model, CancellationToken token)
    {
        await _patronService.AddAsync(model, token);
    }

    /// <summary>
    /// Update an existing patron 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Successfully updated Patron")]
    [SwaggerResponse(404, "Patron Not found")]
    [SwaggerRequestExample(typeof(PatronRequestModel), typeof(PatronsRequestModelExample))]
    public async Task UpdateAsync([FromRoute]int id, [FromBody]PatronRequestModel model, CancellationToken token)
    {
        await _patronService.UpdateAsync(id, model, token);
    }

    /// <summary>
    /// Delete a patron 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Successfully deleted Patron")]
    [SwaggerResponse(404, "Patron Not found")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id, CancellationToken token)
    {
        await _patronService.RemoveAsync(id, token);
        return NoContent();
    }
}
