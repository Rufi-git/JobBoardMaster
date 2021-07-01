using FluentValidation;
using JobBoardTemplate.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Validators
{
    public class BlogValidator : AbstractValidator<ArticleModel>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title can not be null!")
                .Length(5, 100).WithMessage("The Title must be a string with a minimum length of 5 and a maximum length of 100.");
            RuleFor(x => x.ShortDescription).NotNull().WithMessage("Short description can not be null!")
                .Length(10, 300).WithMessage("The Short description must be a string with a minimum length of 10 and a maximum length of 300.");
            RuleFor(x => x.Description).NotNull().WithMessage("Description can not be null!")
                .Length(15, 1000).WithMessage("The Description must be a string with a minimum length of 15 and a maximum length of 1000.");
        }
    }
}