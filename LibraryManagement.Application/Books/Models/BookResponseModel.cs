using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.BorrowRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Books.Models
{
    public class BookResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Quantity { get; set; }       
        public int AuthorId { get; set; }
    }
}
