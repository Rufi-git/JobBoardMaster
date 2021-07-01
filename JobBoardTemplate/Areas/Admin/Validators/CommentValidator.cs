using FluentValidation;
using JobBoardTemplate.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Validators
{
    public class CommentValidator : AbstractValidator<CommentBlogModel>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Comment can not be null!")
                .Length(3, 40).WithMessage("The Name must be a string with a minimum length of 3 and a maximum length of 40.");
            RuleFor(x => x.Text).NotNull().WithMessage("Text can not be null!")
                .Length(1, 500).WithMessage("The Text must be a string with a minimum length of 1 and a maximum length of 500.");
            RuleFor(x => x.Email).NotNull().WithMessage("Email can not be null!")
                .EmailAddress();
            RuleFor(x => x.Website).NotNull().WithMessage("Website can not be null!");
        }
    }
}