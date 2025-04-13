using LibraryManagement.Application.BorrowRecords.Models;
using LibraryManagement.Domain.BorrowRecords;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.BorrowRecords
{
    public class BorrowRecordResponseModelExample : IExamplesProvider<BorrowRecordResponseModel>
    {
        public BorrowRecordResponseModel GetExamples()
        {
            return new BorrowRecordResponseModel
            {
                Id = 1,
                BookId = 1,
                PatronId = 1,
                BorrowDate = new DateTime(2023, 01, 15),
                DueDate = new DateTime(2023, 02, 15),
                ReturnDate = new DateTime(2023, 02, 10),
                Status = Status.Returned
            };
        }
    }
}
