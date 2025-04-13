using LibraryManagement.Domain.Books;

namespace LibraryManagement.Domain.Authors;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }

    // Navigation property
    public ICollection<Book> Books { get; set; }
}
