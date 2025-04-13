using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Authors.Models
{
    public class AuthorRequestModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}
