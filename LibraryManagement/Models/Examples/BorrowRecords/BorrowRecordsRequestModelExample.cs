using LibraryManagement.Application.BorrowRecords.Models;
using LibraryManagement.Domain.BorrowRecords;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.BorrowRecords
{
    public class BorrowRecordsRequestModelExample : IMultipleExamplesProvider<BorrowRecordRequestModel>
    {
        public IEnumerable<SwaggerExample<BorrowRecordRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Borrow record request example 1", new BorrowRecordRequestModel
            {

                BookId = 1,
                PatronId = 1,
                BorrowDate = new DateTime(2023, 01, 15),
                DueDate = new DateTime(2023, 02, 15),
                ReturnDate = new DateTime(2023, 02, 10),
                Status = Status.Returned
            });
            yield return SwaggerExample.Create("Borrow record request example 2", new BorrowRecordRequestModel
            {
                BookId = 2,
                PatronId = 2,
                BorrowDate = new DateTime(2023, 01, 15),
                DueDate = new DateTime(2023, 02, 15),
                ReturnDate = new DateTime(2023, 02, 10),
                Status = Status.Returned
            });
        }
    }
}
