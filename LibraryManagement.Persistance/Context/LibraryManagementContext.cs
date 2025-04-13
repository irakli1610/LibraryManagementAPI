using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.BorrowRecords;
using LibraryManagement.Domain.Patrons;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistance.Context
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Patron> Patrons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementContext).Assembly);

        }


    }
}
