using FluentValidation;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Validators
{
    public class LoginValidator : AbstractValidator<LoginAccountModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Username can not be empty!");
            RuleFor(x => x.Password).NotNull().WithMessage("Password can not be empty!");
        }
    }
}