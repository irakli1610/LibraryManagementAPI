using FluentValidation;
using LibraryManagement.Application.Books.Models;
using LibraryManagement.Application.Validations.Resources;
using System.Data;


namespace LibraryManagement.Application.Validations
{
    public class BookRequestModelValidator : AbstractValidator<BookRequestModel>
    {

        public BookRequestModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull()
                .WithMessage(ValidationMessages.TitleEmpty)
                .MaximumLength(50).WithMessage(ValidationMessages.TitleLength); 

            RuleFor(x => x.ISBN).NotEmpty().NotNull()
                .WithMessage(ValidationMessages.ISBNEmpty)
                .Matches("^[0-9]+$").WithMessage(ValidationMessages.ISBNMustBeNumbers)
                .Length(13).WithMessage(ValidationMessages.ISBNLength);

            RuleFor(x => x.CoverImageUrl).NotNull().NotEmpty().Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage(ValidationMessages.InvalidUrl);

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(ValidationMessages.DescriptionEmpty);

            RuleFor(x => x.PublicationYear).LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage(ValidationMessages.PublicationYearNotFromFuture);

            RuleFor(x => x.Quantity).Must(x => x >= 0).WithMessage(ValidationMessages.QuantityMustBePositive);

            RuleFor(x => x.AuthorId).NotEmpty().WithMessage(ValidationMessages.AuthorIdNotNull);
        }
    }
}
