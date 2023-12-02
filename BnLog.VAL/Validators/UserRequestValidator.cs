using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BnLog.VAL.Request.Security;

namespace BnLog.VAL.Validators
    {
    public class UserRequestValidator : AbstractValidator<UserEditRequest>
        {
        public UserRequestValidator ( )
            {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.NewPassword).NotEmpty().MaximumLength(25);

            }
        }
    }
