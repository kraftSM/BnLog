﻿using BnLog.VAL.Request.Entity;
using FluentValidation;

namespace BnLog.VAL.Validators
    {
    public class TagRequestValidator : AbstractValidator<TagRequest>
        {
        public TagRequestValidator ( )
            {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
            }
        }
    }