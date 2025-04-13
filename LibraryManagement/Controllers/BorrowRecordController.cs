using Asp.Versioning;
using LibraryManagement.API.Models.Examples.Books;
using LibraryManagement.API.Models.Examples.BorrowRecords;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.BorrowRecords;
using LibraryManagement.Application.BorrowRecords.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiVersion(1)]
[ApiVersion(2)]
[Produces("application/json")]
public class BorrowRecordController : ControllerBase
{
    private readonly IBorrowRecordService _borrowRecordService;

    public BorrowRecordController(IBorrowRecordService borrowRecordService)
    {
        _borrowRecordService = borrowRecordService;
    }

    /// <summary>
    /// Get all borrow records with pagination and filtering options
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="bookId"></param>
    /// <param name="patronId"></param>
    /// <param name="borrowDate"></param>
    /// <param name="dueDate"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("borrow-records")]
    [SwaggerResponse(200, "Successfully retrieved borrow records")]
    [SwaggerRequestExample(typeof(BorrowRecordResponseModel), typeof(BorrowRecordsResponseModelExample))]
    public async Task<List<BorrowRecordResponseModel>> GetAllAsyncSearch(int pageNumber, int pageSize, int? bookId, int? patronId, DateTime? borrowDate, DateTime? dueDate, CancellationToken token)
    {
        return await _borrowRecordService.GetAllAsyncSearch(pageNumber, pageSize, bookId, patronId, borrowDate, dueDate, token);
    }

    /// <summary>
    /// Get a specific borrow record 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [SwaggerResponse(200, "Successfully retrieved borrow record")]
    [SwaggerResponse(404, "borrow record Not found")]
    [SwaggerRequestExample(typeof(BorrowRecordResponseModel), typeof(BorrowRecordResponseModelExample))]
    public async Task<BorrowRecordResponseModel> GetByIdAsync(int id, CancellationToken token)
    {
        return await _borrowRecordService.GetByIdAsync(id, token);
    }

    /// <summary>
    ///  Create a new borrow record
    /// </summary>
    /// <param name="borrowRecordRequestModel"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("borrow-records")]
    [SwaggerResponse(200, "Successfully created borrow record")]
    [SwaggerResponse(404, "book or patron Not found")]
    [SwaggerResponse(404, "not enough books available")]
    [SwaggerRequestExample(typeof(BorrowRecordRequestModel), typeof(BorrowRecordsRequestModelExample))]
    public async Task AddAsync(BorrowRecordRequestModel borrowRecordRequestModel, CancellationToken token)
    {
        await _borrowRecordService.AddAsync(borrowRecordRequestModel, token);
    }

    /// <summary>
    /// Return a book 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("borrow-records/{id}/return")]
    [SwaggerResponse(200, "Successfully returned book")]
    [SwaggerResponse(404, "borrow record or book Not found")]
    [SwaggerResponse(409, "book is already returned")]
    [SwaggerResponse(415, "specific book is not supported")]
    public async Task ReturnBook(int id, CancellationToken token)
    {
        await _borrowRecordService.ReturnBook(id, token);
    }

    /// <summary>
    /// Get all overdue books 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("borrow-records/overdue")]
    [SwaggerResponse(200, "Successfully retrieved overdue books")]

    [SwaggerRequestExample(typeof(BookResponseModel), typeof(BooksResponseModelExample))]

    public async Task<List<BookResponseModel>> GetAllOverdueBooksAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _borrowRecordService.GetAllOverdueBooksAsync(pageNumber, pageSize, token);
    }

}
