using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Patrons.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Patron
{
    public class PatronsRequestModelExample : IMultipleExamplesProvider<PatronRequestModel>
    {
        public IEnumerable<SwaggerExample<PatronRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create("John", new PatronRequestModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "email@email.com",
                MembershipDate = new DateTime(1990, 12, 12),
            });
            yield return SwaggerExample.Create("Sam", new PatronRequestModel
            {
                FirstName = "Sam",
                LastName = "Smith",
                Email = "email@email.com",
                MembershipDate = new DateTime(1990, 12, 12),
            });

        }
    }
}
