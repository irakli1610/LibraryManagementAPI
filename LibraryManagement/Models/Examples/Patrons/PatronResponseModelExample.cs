using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Patrons.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.Patron;
public class PatronResponseModelExample : IExamplesProvider<PatronResponseModel>
{    public PatronResponseModel GetExamples()
    {
        return new PatronResponseModel
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "somerandomemail@gmail.com",
            MembershipDate = new DateTime(1990, 12, 12),
        };
    }
}
