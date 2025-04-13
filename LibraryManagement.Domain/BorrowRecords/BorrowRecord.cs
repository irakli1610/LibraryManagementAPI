using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.Patrons;

namespace LibraryManagement.Domain.BorrowRecords;

public class BorrowRecord
{
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? PatronId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Status Status { get; set; }

    //Navigation Property
    public Book Book { get; set; }
    public Patron Patron { get; set; }
}
