using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using FluentValidation;

namespace CodevDone.CQRS.Domain.Validators.UserProfileValidators
{
    public class BasicInfoValidator : AbstractValidator<BasicInfo>
    {
        public BasicInfoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long")
                .MaximumLength(50).WithMessage("First name must be at most 50 characters long");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long")
                .MaximumLength(50).WithMessage("Last name must be at most 50 characters long");
            RuleFor(x => x.EmailAddres)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Email address is not valid");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required");
            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .InclusiveBetween(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-18))
                .WithMessage("You must be at between 18 years old and 80 years old");

        }
    }
}