using FluentValidation;
using JobBoardTemplate.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Validators
{
    public class JobValidator : AbstractValidator<JobCategoryModel>
    {
        public JobValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name can not be empty!")
                 .Length(5, 40).WithMessage("The Name must be a string with a minimum length of 5 and a maximum length of 40.");

            RuleFor(x => x.Location).NotNull().WithMessage("Location can not be empty!");

            RuleFor(x => x.WorkDuration).NotNull().WithMessage("Work duration can not be null!");

            RuleFor(x => x.Vacancy).NotNull().WithMessage("Vacancy can not be null!");

            RuleFor(x => x.Description).NotNull().WithMessage("Description can not be null!")
                .MaximumLength(800).WithMessage("The Name must be a string with a maximum length of 800.");

            RuleFor(x => x.Responsibility).NotNull().WithMessage("Responsibility can not be null!")
                .MaximumLength(500).WithMessage("The Responsibility must be a string with a maximum length of 500.");

            RuleFor(x => x.Qualifications).NotNull().WithMessage("Qualifications can not be null!")
               .MaximumLength(500).WithMessage("The Qualifications must be a string with a maximum length of 500.");

            RuleFor(x => x.Benefits).NotNull().WithMessage("Benefits can not be null!")
              .MaximumLength(600).WithMessage("The Benefits must be a string with a maximum length of 600.");

            RuleFor(x => x.SalaryFrom).NotNull().WithMessage("Salary from can not be null!");

            RuleFor(x => x.SalaryTo).NotNull().WithMessage("Salary to can not be null!");
        }
    }
}