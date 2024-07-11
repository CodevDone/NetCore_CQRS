
using FluentValidation;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;

namespace CodevDone.CQRS.Domain.Validators.PostValidator
{
    public class PostCommentValidator : AbstractValidator<PostComment>
    {
        public PostCommentValidator()
        {
            RuleFor(pc => pc.Text)
               .NotNull().WithMessage("Text  should not be null")
               .NotEmpty().WithMessage("Text  is required")
               .MinimumLength(1000).WithMessage("Text  must be at least 1000 characters long")
               .MaximumLength(1).WithMessage("Text  must be at most 1 characters long");

        }

    }
}