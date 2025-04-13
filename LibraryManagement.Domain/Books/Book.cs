using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.BorrowRecords;

namespace LibraryManagement.Domain.Books;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public string Description { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int AuthorId { get; set; }

    //Navigation property
    public Author Author { get; set; }  

    public ICollection<BorrowRecord> BorrowRecords { get; set; }
}
