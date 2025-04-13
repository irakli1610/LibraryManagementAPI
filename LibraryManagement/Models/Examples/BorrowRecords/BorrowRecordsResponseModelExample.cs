using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.BorrowRecords.Models;
using LibraryManagement.Domain.BorrowRecords;
using Swashbuckle.AspNetCore.Filters;

namespace LibraryManagement.API.Models.Examples.BorrowRecords
{
    public class BorrowRecordsResponseModelExample : IMultipleExamplesProvider<List<BorrowRecordResponseModel>>
    {
        public IEnumerable<SwaggerExample<List<BorrowRecordResponseModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("Multiple borrow records  example", new List<BorrowRecordResponseModel>
            {
                new BorrowRecordResponseModel
                {
                    Id = 1,
                    BookId = 1,
                    PatronId = 1,
                    BorrowDate = new DateTime(2023, 01, 15),
                    DueDate = new DateTime(2023, 02, 15),
                    ReturnDate = new DateTime(2023, 02, 10),
                    Status = Status.Returned
                },
                new BorrowRecordResponseModel
                {
                    Id = 2,
                    BookId = 1,
                    PatronId = 2,
                    BorrowDate = new DateTime(2023, 03, 10),
                    DueDate = new DateTime(2023, 04, 10),
                    ReturnDate = null,
                    Status = Status.Borrowed
                }

            });
        }
    }
}
