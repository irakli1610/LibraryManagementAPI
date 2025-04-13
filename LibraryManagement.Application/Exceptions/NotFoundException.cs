using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Code = "EntityNotFound";
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
