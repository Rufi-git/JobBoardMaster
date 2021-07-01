using FluentValidation;
using JobBoardTemplate.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Validators
{
    public class TagValidator : AbstractValidator<TagBlogModel>
    {
        public TagValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name can not be null!");
        }
    }
}