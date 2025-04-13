using LibraryManagement.Domain.BorrowRecords;

namespace LibraryManagement.Application.BorrowRecords.Models
{
    public class BorrowRecordResponseModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PatronId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Status Status { get; set; }
    }
}
