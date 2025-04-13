using FluentValidation;
using LibraryManagement.Application.Patrons.Models;
using LibraryManagement.Application.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validations;

public class PatronRequestModelValidator : AbstractValidator<PatronRequestModel>
{
    public PatronRequestModelValidator()
    {
        RuleFor(patron => patron.FirstName).NotNull()
            .NotEmpty().WithMessage(ValidationMessages.FirstNameEmpty)
            .MaximumLength(50).WithMessage(ValidationMessages.FirstNameLength);

        RuleFor(patron => patron.LastName).NotNull()
            .NotEmpty().WithMessage(ValidationMessages.LastNameEmpty)
            .MaximumLength(50).WithMessage(ValidationMessages.LastNameLength);

        RuleFor(patron => patron.Email).NotNull()
            .NotEmpty().WithMessage(ValidationMessages.EmailEmpty)
            .EmailAddress().WithMessage(ValidationMessages.EmailInvalid);

        RuleFor(patron => patron.MembershipDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage(ValidationMessages.MembershipDateNotFromFuture);

    }
}
