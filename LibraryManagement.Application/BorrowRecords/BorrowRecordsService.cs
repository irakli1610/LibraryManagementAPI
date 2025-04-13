using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.BorrowRecords.Models;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Application.Repositories;
using LibraryManagement.Domain.BorrowRecords;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.BorrowRecords
{
    public class BorrowRecordsService : IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _borrowRecordRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IPatronRepository _patronRepository;
        private readonly IContextWrapper _contextWrapper;

        public BorrowRecordsService(IBorrowRecordRepository borrowRecordRepository,IBookRepository bookRepository,IPatronRepository patronRepository,IContextWrapper contextWrapper)
        {
            _borrowRecordRepository = borrowRecordRepository;
            _bookRepository = bookRepository;
            _patronRepository = patronRepository;
            _contextWrapper = contextWrapper;
        }

        public async Task<List<BorrowRecordResponseModel>> GetAllAsyncSearch(int pageNumber, int pageSize, int? bookId, int? patronId, DateTime? borrowDate, DateTime? dueDate, CancellationToken token)
        {
            var borrowRecords = await _borrowRecordRepository.GetAllAsyncSearch(pageNumber, pageSize, bookId, patronId, borrowDate, dueDate, token);
            var records = borrowRecords.Adapt<List<BorrowRecordResponseModel>>();
            return records;
        }

        public async Task<BorrowRecordResponseModel> GetByIdAsync(int id, CancellationToken token)
        {
            var borrowRecordById = await _borrowRecordRepository.GetByIdAsync(id, token);

            if (borrowRecordById == null)
            {
                throw new NotFoundException(AppExceptions.BorrowRecordNotFound);
            }

            return borrowRecordById.Adapt<BorrowRecordResponseModel>();
        }

        public async Task AddAsync(BorrowRecordRequestModel borrowRecordRequestModel, CancellationToken token)
        {
            int id = (int)borrowRecordRequestModel.BookId;//checked during validation
            var book = await _bookRepository.GetByIdAsync(id, token);
            if (book == null)
            {
                throw new NotFoundException(AppExceptions.BookNotFound);
            }
            if(book.Quantity == 0)
            {
                throw new NotEnoughBooksException(AppExceptions.BookNotAvailable);
            }

            int patronId = (int)borrowRecordRequestModel.PatronId;//checked during validation
            var patronExists = await _patronRepository.ExistsAsync(x=>x.Id == patronId, token);
            if (!patronExists)
            {
                throw new NotFoundException(AppExceptions.PatronNotFound);
            }

            // start transaction
            var transaction = await _contextWrapper.BeginTransaction();
            try
            {
                var borrowRecord = borrowRecordRequestModel.Adapt<BorrowRecord>();
                book.Quantity -= 1;
                borrowRecord.BorrowDate = DateTime.Now;
                borrowRecord.Status = Status.Borrowed;
                await _bookRepository.UpdateAsync(book, token);
                await _borrowRecordRepository.AddAsync(borrowRecord, token);
                await transaction.CommitAsync(token);
            }
            catch
            {
                await transaction.RollbackAsync(token);
                throw;
            }
        }

        public async Task ReturnBook(int id, CancellationToken token)
        {
            var record = await _borrowRecordRepository.GetByIdAsync(id, token);
            if(record == null)
            {
                throw new NotFoundException(AppExceptions.BorrowRecordNotFound);
            }
            if(record.Status == Status.Returned)
            {
                throw new BookAlreadyReturnedException(AppExceptions.BookAlreadyReturned);
            }


            if (!record.BookId.HasValue)
            {
                throw new BookNotSupportedException(AppExceptions.BookNoLongerSupported);
            }
            int bookId = (int)record.BookId;       
            var book = await _bookRepository.GetByIdAsync(bookId, token);
            
            if (book == null)
            {
                throw new NotFoundException(AppExceptions.BookNotFound);
            }

            // start transaction
            var transaction = await _contextWrapper.BeginTransaction();
            try
            {
                book.Quantity += 1;
                record.Status = Status.Returned;
                record.ReturnDate = DateTime.Now;
                await _bookRepository.UpdateAsync(book, token);
                await _borrowRecordRepository.UpdateAsync(record, token);
                await transaction.CommitAsync(token);
            }
            catch
            {
                await transaction.RollbackAsync(token);
                throw;
            }
        }

        public async  Task<List<BookResponseModel>> GetAllOverdueBooksAsync(int pageNumber, int pageSize, CancellationToken token)
        {
            var overdueBooks = await _borrowRecordRepository.GetAllOverdueBooksAsync(pageNumber, pageSize, token);
            return overdueBooks.Adapt<List<BookResponseModel>>();
        }
    }
}
