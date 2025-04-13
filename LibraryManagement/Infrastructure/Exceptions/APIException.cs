using LibraryManagement.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagement.API.Infrastructure.Exceptions
{
    public class APIException : ProblemDetails
    {
       
        public const string UnhandlerErrorCode = "UnhandledError";
        private HttpContext _httpContext;
        private Exception _exception;
        private readonly ILogger _logger; 
        public LogLevel LogLevel { get; set; }
        public string Code { get; set; }
        public string? TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string?)traceId;
                }

                return null;
            }

            set => Extensions["TraceId"] = value;
        }

        public APIException(HttpContext httpContext, Exception exception, ILogger logger)
        {
            _httpContext = httpContext;
            _exception = exception;
            TraceId = httpContext.TraceIdentifier;
            _logger = logger;
            Instance = _httpContext.Request.Path;
            HandleException((dynamic)exception);
            
        }

        private void HandleException(NotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            _logger.LogInformation("NotFoundException: {Message}", exception.Message);
        }


        private void HandleException(NotEnoughBooksException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict; // 409 Conflict
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            _logger.LogInformation("NotEnoughBooksException: {Message}", exception.Message);
        }


        private void HandleException(BookAlreadyReturnedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict; // 409 Conflict
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            _logger.LogInformation("BookAlreadyReturnedException: {Message}", exception.Message);
        }

        private void HandleException(BookNotSupportedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.UnsupportedMediaType; // 415 Unsupported Media Type
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/415";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            _logger.LogInformation("BookNotSupportedException: {Message}", exception.Message);
        }



        private void HandleException(DbUpdateException exception)
        {

            Code = "DatabaseUpdateError";
            Status = (int)HttpStatusCode.Conflict; // 409 Conflict for constraint violations
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = "A database constraint was violated.";
            LogLevel = LogLevel.Warning;

            if (exception.InnerException is SqlException sqlEx)
            {
                if (sqlEx.Number == 547) // Foreign Key violation
                {
                    Code = "ForeignKeyViolation";
                    Title = "The operation violates a foreign key constraint.";
                }
                else if (sqlEx.Number == 2601 || sqlEx.Number == 2627) // Unique constraint violation
                {
                    Code = "UniqueConstraintViolation";
                    Title = "A unique constraint was violated.";
                }
            }
            _logger.LogWarning("DbUpdateException: {Message}", exception.Message);

        }

        private void HandleException(Exception exception)
        {
            Code = UnhandlerErrorCode;
            Status = (int)HttpStatusCode.InternalServerError; 
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"; 
            Title = "An unexpected error occurred on the server."; 
            LogLevel = LogLevel.Error; 
            Instance = _httpContext.Request.Path;
            Detail = $"Exception details: {exception.Message}";
            _logger.LogError(exception, "Unhandled exception occurred.");

        }
    }
}
