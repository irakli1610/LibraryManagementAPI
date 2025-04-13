namespace LibraryManagement.Application.Authors.Models
{
    public class AuthorResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
