using LibraryManagement.Application.Authors.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Author
{
    public class AuthorsRequestModelExample : IMultipleExamplesProvider<AuthorRequestModel>
    {
        public IEnumerable<SwaggerExample<AuthorRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create("John Doe", new AuthorRequestModel
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 12, 12),
                Biography = "random biography for John Doe"
            });
            yield return SwaggerExample.Create("Sam Smith", new AuthorRequestModel
            {
                FirstName = "Sam",
                LastName = "Smith",
                DateOfBirth = new DateTime(1885, 09, 01),
                Biography = "random biography for Sam Smith"
            });
        }
    }
}
