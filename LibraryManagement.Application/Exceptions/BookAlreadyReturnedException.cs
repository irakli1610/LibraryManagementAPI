using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Exceptions
{
    public class BookAlreadyReturnedException : Exception
    {
        public string Code = "BookIsAlreadyReturned";
        public BookAlreadyReturnedException(string message) : base(message)
        {
            
        }
    }
}
