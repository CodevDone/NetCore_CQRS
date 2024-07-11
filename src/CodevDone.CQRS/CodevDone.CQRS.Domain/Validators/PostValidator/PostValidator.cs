using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using FluentValidation;

namespace CodevDone.CQRS.Domain.Validators.PostValidator
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.TextContent)
                .NotNull().WithMessage("TextContent  should not be null")
                .NotEmpty().WithMessage("TextContent  is required");
        }
    }
}