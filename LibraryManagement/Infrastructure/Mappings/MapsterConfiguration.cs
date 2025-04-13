using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.BorrowRecords.Models;
using LibraryManagement.Application.Patrons.Models;
using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.BorrowRecords;
using LibraryManagement.Domain.Patrons;
using Mapster;

namespace LibraryManagement.API.Infrastructure.Mappings;

public static class MapsterConfiguration
{
    public static void RegisterMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Book, BookResponseModel>.NewConfig().TwoWays();

        TypeAdapterConfig<Book,BookRequestModel>.NewConfig().TwoWays();


        TypeAdapterConfig<Author, AuthorResponseModel>.NewConfig().TwoWays();

        TypeAdapterConfig<Author, AuthorRequestModel>.NewConfig().TwoWays();


        TypeAdapterConfig<Patron, PatronResponseModel>.NewConfig().TwoWays();

        TypeAdapterConfig<Patron, PatronRequestModel>.NewConfig().TwoWays();


        TypeAdapterConfig<BorrowRecord, BorrowRecordResponseModel>.NewConfig().TwoWays();

        TypeAdapterConfig<BorrowRecord, BorrowRecordRequestModel>.NewConfig().TwoWays();
    }

}
