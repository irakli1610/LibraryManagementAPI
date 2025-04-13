using LibraryManagement.Application.Patrons.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Patron;

public class PatronsResponseModelExample : IMultipleExamplesProvider<List<PatronResponseModel>>
{
    public IEnumerable<SwaggerExample<List<PatronResponseModel>>> GetExamples()
    {
        yield return SwaggerExample.Create("Multiple patrons example", new List<PatronResponseModel>
        {
            new PatronResponseModel
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                MembershipDate = new DateTime(2020, 03, 15)
            },
            new PatronResponseModel
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                MembershipDate = new DateTime(2019, 11, 10)
            },
            new PatronResponseModel
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                MembershipDate = new DateTime(2021, 06, 22)
            },
            new PatronResponseModel
            {
                Id = 4,
                FirstName = "Bob",
                LastName = "Brown",
                Email = "bob.brown@example.com",
                MembershipDate = new DateTime(2022, 08, 30)
            }

        });
    }
}