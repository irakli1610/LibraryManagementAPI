using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Books;
public class BookResponseModelExample : IExamplesProvider<BookResponseModel>
{
    public BookResponseModel GetExamples()
    {
        return new BookResponseModel
        {
            Id = 5,
            Title = "LOTR",
            ISBN = "1248975684242",
            PublicationYear = 1881,
            Description = "description for LOTR",
            CoverImageUrl = "https://www.example.com/book2.jpg",
            Quantity = 4,
            AuthorId = 1
            
        };
    }
}
