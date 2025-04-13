using LibraryManagement.API.Infrastructure.Exceptions;
using Newtonsoft.Json;

namespace LibraryManagement.API.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new APIException(context, ex, _logger);

            var result = JsonConvert.SerializeObject(error);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status!.Value;

            await context.Response.WriteAsync(result);
        }
    }
}
