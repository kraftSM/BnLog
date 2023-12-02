using BnLog.VAL.Request.Entity;
using FluentValidation;

namespace BnLog.VAL.Validators
    {
    public class CommentRequestValidator : AbstractValidator<CommentRequest>
        {
        public CommentRequestValidator ( )
            {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Body).NotEmpty().MaximumLength(500);
            }
        }
    }
