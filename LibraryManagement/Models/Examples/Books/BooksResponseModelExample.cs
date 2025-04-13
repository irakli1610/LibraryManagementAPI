using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Books
{
    public class BooksResponseModelExample : IMultipleExamplesProvider<List<BookResponseModel>>
    {
        public IEnumerable<SwaggerExample<List<BookResponseModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("Multiple books example", new List<BookResponseModel>
            {
                new BookResponseModel
                {

                    Id = 5,
                    Title = "LOTR",
                    ISBN = "1248975684302",
                    PublicationYear = 1881,
                    Description = "description for LOTR",
                    CoverImageUrl = "https://www.example.com/book2.jpg",
                    Quantity = 4,
                    AuthorId =1
                },
                 new BookResponseModel
                {

                    Id = 4,
                    Title = "Foundation",
                    ISBN = "8746049875315",
                    PublicationYear = 1947,
                    Description = "description for Foundation",
                    CoverImageUrl = "https://www.example.com/book3.jpg",
                    Quantity = 2,
                    AuthorId =1
                }
            });
        }
    }
}
