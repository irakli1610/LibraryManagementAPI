namespace LibraryManagement.Application.Exceptions;
public class NotEnoughBooksException : Exception
{
    public string Code = "NotEnoughBooks";
    public NotEnoughBooksException(string message) : base(message)
    {

    }
}
