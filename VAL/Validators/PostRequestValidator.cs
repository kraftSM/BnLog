using BnLog.VAL.Request.Entity;
using FluentValidation;

namespace BnLog.VAL.Validators
    {
    public class PostRequestValidator : AbstractValidator<PostEditRequest>
        {
        public PostRequestValidator ( )
            {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Body).NotEmpty();
            }
        }
    }
