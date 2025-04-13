using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Books.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Books
{
    public class BooksRequestModelExample : IMultipleExamplesProvider<BookRequestModel>
    {
        public IEnumerable<SwaggerExample<BookRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Metro 2033", new BookRequestModel
            {
                Title = "Metro 2033",
                ISBN = "4569781483269",
                PublicationYear = 2019,
                Description = "Metro description",
                CoverImageUrl = "https://www.example.com/book7.jpg",
                Quantity = 10,
                AuthorId = 2
            });
            yield return SwaggerExample.Create("Dark matter", new BookRequestModel
            {
                Title = "Dark matter",
                ISBN = "1796387989426",
                PublicationYear = 200,
                Description = "Dark Matter by blake crauch",
                CoverImageUrl = "https://www.example.com/book11.jpg",
                Quantity = 5,
                AuthorId = 2
            });           
        }
    }
}
