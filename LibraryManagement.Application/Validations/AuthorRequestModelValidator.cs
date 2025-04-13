using FluentValidation;
using LibraryManagement.Application.Authors.Models;
using LibraryManagement.Application.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validations;

public class AuthorRequestModelValidator : AbstractValidator<AuthorRequestModel>
{
    public AuthorRequestModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().NotNull()
            .WithMessage(ValidationMessages.FirstNameEmpty)
            .MaximumLength(50).WithMessage(ValidationMessages.FirstNameLength);

        RuleFor(x => x.LastName).NotEmpty().NotNull()
            .WithMessage(ValidationMessages.LastNameEmpty)
            .MaximumLength(50).WithMessage(ValidationMessages.LastNameLength);

        RuleFor(x => x.Biography).NotEmpty().NotNull()
            .WithMessage(ValidationMessages.BiographyEmpty);

        RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(DateTime.Now)
            .WithMessage(ValidationMessages.DateOfBirthNotFromFuture);

    }
}

