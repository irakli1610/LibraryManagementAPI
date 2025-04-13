using LibraryManagement.Application;
using LibraryManagement.Application.Authors;
using LibraryManagement.Application.Books;
using LibraryManagement.Application.BorrowRecords;
using LibraryManagement.Application.Patrons;
using LibraryManagement.Application.Repositories;
using LibraryManagement.Infrastructure;
using LibraryManagement.Infrastructure.Authors;
using LibraryManagement.Infrastructure.Books;
using LibraryManagement.Infrastructure.BorrowRecords;
using LibraryManagement.Infrastructure.Patrons;

namespace LibraryManagement.API.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPatronService, PatronService>();
        services.AddScoped<IBorrowRecordService, BorrowRecordsService>();
        services.AddScoped<IContextWrapper, ContextWrapper>();

        AddRepositories(services);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPatronRepository, PatronRepository>();
        services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
    }
}
