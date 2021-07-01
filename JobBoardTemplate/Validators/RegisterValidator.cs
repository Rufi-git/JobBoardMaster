using FluentValidation;
using JobBoardTemplate.Data;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name can not be empty");

            RuleFor(x => x.Surname).NotNull().WithMessage("Surname can not be empty");

            RuleFor(x => x.Password).NotNull().WithMessage("Password can not be empty")
                                    .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                                    .Matches("[A-Z]").WithMessage("Password must contain at least 1 uppercase letter")
                                    .Matches("[a-z]").WithMessage("Password must contain at least 1 lowercase letter")
                                    .Matches("[0-9]").WithMessage("Password must contain a number");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Confirm password can not be empty")
                                           .Equal(x => x.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.Age).NotNull().WithMessage("Age can not be empty")
                               .Must(AgeValidation).WithMessage("Age must be between 10 and 120");

            RuleFor(x => x.Email).NotNull().WithMessage("Email can not be empty")
                                 .EmailAddress().WithMessage("Email is not in a corrext form")
                                 .Must(IsEmailUnique).WithMessage("Email has already taken");

            RuleFor(x => x.UserName).NotNull().WithMessage("UserName can not be empty")
                                    .Must(IsNameUnique).WithMessage("Name has already taken");

            RuleFor(x => x.Gender).NotNull().WithMessage("Gender can not be empty");
        }
        JobDbContext db = new JobDbContext();

        public bool IsEmailUnique(string email)
        {
            var userEmail = db.AppUsers.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (userEmail == null)
            {
                return true;
            }

            return false;
        }

        public bool IsNameUnique(string name)
        {
            var userName = db.AppUsers.Where(x => x.UserName.ToLower() == name.ToLower()).FirstOrDefault();
            if (userName == null)
            {
                return true;
            }

            return false;
        }

        public bool AgeValidation(byte age)
        {
            if (age > 10 && age < 120)
            {
                return true;
            }
            return false;
        }

        public bool PasswordValdiation(string ConfirmPassword, string Password)
        {
            if (ConfirmPassword == Password)
            {
                return true;
            }
            return false;
        }
    }
}