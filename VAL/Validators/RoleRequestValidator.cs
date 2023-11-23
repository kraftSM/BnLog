using BnLog.VAL.Request.Security;
using FluentValidation;
using BnLog.VAL.Models;

namespace BnLog.VAL.Validators
{
    public class RoleRequestValidator : AbstractValidator<RoleEditRequest>
        {
        public RoleRequestValidator ( )
            {
            RuleFor(x => x.Name).NotEmpty();
            }

        public bool ExistingRole ( string roleName )
            {
            for (int i = 0; i < RoleValues.Roles.Count(); i++)
                {
                if (roleName == RoleValues.Roles[i])
                    return true;
                }
            return false;
            }
        }
    }
