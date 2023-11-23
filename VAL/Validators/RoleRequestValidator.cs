using BnLog.VAL.Request.Security;
using FluentValidation;
using BnLog.VAL.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BnLog.VAL.Validators
{
    public class RoleRequestValidator : AbstractValidator<RoleEditRequest>
        {
        private const int cntName_01 = 10;
        private const string errMsgCntName_01 = @"Please enter correct name (Len =< {cntName_01}";
        private const string errMsgCntName_02 = "Role Name is not Acceptable";
        private const string errMsgSecLvl_01 = "Security Level for Role Name must be in range[0...3]";
        public RoleRequestValidator ( )
            {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(cntName_01).WithMessage(errMsgCntName_01);
            RuleFor(x => x.Name).Must(IsAcceptableRole).WithMessage(errMsgCntName_02);
            RuleFor(x => x.SecurityLvl).NotNull().NotEmpty().InclusiveBetween(0,3).WithMessage(errMsgSecLvl_01);
            }

        //Попытка ограничения списка ролей by RoleRequestValidator
        public bool IsAcceptableRole ( string roleName )
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
