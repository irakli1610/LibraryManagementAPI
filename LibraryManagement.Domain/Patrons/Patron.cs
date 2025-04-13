using LibraryManagement.Domain.BorrowRecords;

namespace LibraryManagement.Domain.Patrons;

public class Patron
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime MembershipDate { get; set; }

    // Navigation property
    public ICollection<BorrowRecord> BorrowRecords { get; set; }
}
