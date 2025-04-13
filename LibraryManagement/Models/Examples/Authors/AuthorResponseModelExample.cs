using LibraryManagement.Application.Authors.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Author
{
    public class AuthorResponseModelExample : IExamplesProvider<AuthorResponseModel>
    {
        public AuthorResponseModel GetExamples()
        {
            return new AuthorResponseModel
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 12, 12),
                Biography = "John's biography"
            };
        }
    }
}
