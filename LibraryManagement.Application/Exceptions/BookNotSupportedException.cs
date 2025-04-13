using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Exceptions
{
    public class BookNotSupportedException : Exception
    {
        public string Code = "BookNoLOngerSupported";
        public BookNotSupportedException(string message) : base(message)
        {

        }
    }
}
