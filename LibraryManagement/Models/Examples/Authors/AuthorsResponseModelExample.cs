using LibraryManagement.Application.Authors.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Author
{
    public class AuthorsResponseModelExample : IMultipleExamplesProvider<List<AuthorResponseModel>>
    {
        public IEnumerable<SwaggerExample<List<AuthorResponseModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("Multiple authors example", new List<AuthorResponseModel>
            {
                new AuthorResponseModel
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 12, 12),
                    Biography = "John's biography"
                },
                new AuthorResponseModel
                {
                    Id = 2,
                    FirstName = "Sam",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1980, 05, 15),
                    Biography = "Sam's biography"
                }
            });
        }
    }
}
