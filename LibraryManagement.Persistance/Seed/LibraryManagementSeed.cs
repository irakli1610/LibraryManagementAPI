using LibraryManagement.Domain.Authors;
using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.BorrowRecords;
using LibraryManagement.Domain.Patrons;
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistance.Seed;

public class LibraryManagementSeed
{
    public static void Initialize(IServiceProvider service)
    {
        using var scope = service.CreateAsyncScope();

        var database = scope.ServiceProvider.GetRequiredService<LibraryManagementContext>();

        Migrate(database);

        SeedEverything(database);
    }

    private static void Migrate(LibraryManagementContext context)
    {
        context.Database.Migrate();
    }



    private static void SeedEverything(LibraryManagementContext context)
    {
        bool seeded = false;
        SeedAuthorsAndBooks(context, ref seeded);
        SeedPatrons(context, ref seeded);
        
        if (seeded)
        {
            context.SaveChanges();
        }
        SeedBorrowRecords(context, ref seeded);
        if (seeded)
        {
            context.SaveChanges();
        }
    }

    private static void SeedAuthorsAndBooks(LibraryManagementContext context, ref bool seeded)
    {
        var authors = new List<Author>
            {
                new Author { FirstName = "George", LastName = "Orwell", Biography = "British writer", DateOfBirth = new DateTime(1903, 6, 25) },
                new Author { FirstName = "J.K.", LastName = "Rowling", Biography = "British author, known for Harry Potter", DateOfBirth = new DateTime(1965, 7, 31) }
            };

        foreach (var author in authors)
        {
            if (!context.Authors.Any(a => a.FirstName == author.FirstName && a.LastName == author.LastName))
            {
                context.Authors.Add(author);
                seeded = true;
            }
        }

        var books = new List<Book>
            {
                new Book { Title = "1984", ISBN = "9780451524935", PublicationYear = 1949, Description = "Dystopian novel", CoverImageUrl = "url1", Quantity = 5, Author = authors[0] },
                new Book { Title = "Harry Potter and the Philosopher's Stone", ISBN = "9780747532743", PublicationYear = 1997, Description = "Fantasy novel", CoverImageUrl = "url2", Quantity = 10, Author = authors[1] }
            };

        foreach (var book in books)
        {
            if (!context.Books.Any(b => b.ISBN == book.ISBN))
            {
                context.Books.Add(book);
                seeded = true;
            }
        }
    }


    private static void SeedPatrons(LibraryManagementContext context, ref bool seeded)
    {
        var patrons = new List<Patron>
            {
                new Patron { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", MembershipDate = DateTime.UtcNow.AddYears(-2) },
                new Patron { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", MembershipDate = DateTime.UtcNow.AddYears(-1) }
            };

        foreach (var patron in patrons)
        {
            if (!context.Patrons.Any(p => p.Email == patron.Email))
            {
                context.Patrons.Add(patron);
                seeded = true;
            }
        }
    }

    private static void SeedBorrowRecords(LibraryManagementContext context, ref bool seeded)
    {
        var books = context.Books.ToList(); 
        var patrons = context.Patrons.ToList();

        if (books.Count < 2 || patrons.Count < 2) return; 

        var borrowRecords = new List<BorrowRecord>
        {
            new BorrowRecord
            {
                BookId = books[0].Id, 
                PatronId = patrons[0].Id,
                BorrowDate = DateTime.UtcNow.AddDays(-10),
                DueDate = DateTime.UtcNow.AddDays(10),
                Status = Status.Borrowed
            },
            new BorrowRecord
            {
                BookId = books[1].Id,
                PatronId = patrons[1].Id,
                BorrowDate = DateTime.UtcNow.AddDays(-5),
                DueDate = DateTime.UtcNow.AddDays(5),
                Status = Status.Borrowed
            }
        };


        foreach (var record in borrowRecords)
        {
            if (!context.BorrowRecords.Any(br => br.BookId == record.BookId && br.PatronId == record.PatronId))
            {
                context.BorrowRecords.Add(record);
                seeded = true;
            }
        }
    }


}
