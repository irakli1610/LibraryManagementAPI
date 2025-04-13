using FluentValidation;
using LibraryManagement.Application.BorrowRecords.Models;
using LibraryManagement.Application.Validations.Resources;

namespace LibraryManagement.Application.Validations
{
    class BorrowRecordRequestModelValidator : AbstractValidator<BorrowRecordRequestModel>
    {
        public BorrowRecordRequestModelValidator()
        {
            RuleFor(x => x.BookId).NotNull().WithMessage(ValidationMessages.BookIdEmpty);

            RuleFor(x => x.PatronId).NotNull().WithMessage(ValidationMessages.PatronIdEmpty);

            RuleFor(x => x.BorrowDate).NotNull().WithMessage(ValidationMessages.BorrowDateEmpty)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(ValidationMessages.BorrowDateFromFuture);

            RuleFor(x => x.DueDate).NotNull().WithMessage(ValidationMessages.DueDateEmpty)
                .GreaterThan(x => x.BorrowDate)
                .WithMessage(ValidationMessages.DueDateMustBeAfterBorrowDate);

            RuleFor(x => x.ReturnDate)
                .GreaterThanOrEqualTo(x => x.BorrowDate)
                .When(x => x.ReturnDate.HasValue)
                .WithMessage(ValidationMessages.ReturnDateBeforeBorrowDate);

        }
    }
}
