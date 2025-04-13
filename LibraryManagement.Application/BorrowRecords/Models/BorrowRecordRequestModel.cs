using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.BorrowRecords;
using LibraryManagement.Domain.Patrons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.BorrowRecords.Models
{
    public class BorrowRecordRequestModel
    {
        public int? BookId { get; set; }
        public int? PatronId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Status Status { get; set; }

    }
}
