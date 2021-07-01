using FluentValidation.Results;
using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Areas.Admin.Validators;
using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public TagController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Admin/Tag
        //public ActionResult TagsNotInBlog(int id)
        ////{
        ////    _jobDbContext.Tags.Select(t => new TagBlogModel
        ////    {
        ////        Id = t.Id,
        ////        IsActive = t.isActive,
        ////        Name = t.Name,
        ////        Order = t.Order
        ////    })/*.ToList().Find(x=>x.Id == id).Blogs.Where(x => x.Id != id).ToList();*/
        ////    return View();
        //}

        [HttpGet]
        public ActionResult EditTag(int id)
        {

            var tag = _jobDbContext.Tags.Select(t => new TagBlogModel
            {
                Id = t.Id,
                IsActive = t.IsActive,
                Name = t.Name,
                Order = t.Order,
                Blogs = t.Blogs.Select(b => new ArticleModel
                {
                    ShortDescription = b.ShortDescription,
                    Description = b.Description,
                    Id = b.Id,
                    ImagePath = b.ImagePath,
                    isActive = b.isActive,
                    PublishDate = b.PublishDate,
                    isPopular = b.isPopular,
                    Order = b.Order,
                    Title = b.Title,
                    WrittenDate = b.WrittenDate,
                }).ToList()
            }).FirstOrDefault(x => x.Id == id);
            TempData["TagId"] = tag.Id;
            return View(tag);
        }

        [HttpPost]
        public ActionResult EditTag(int id, TagBlogModel tagModel)
        {
            var tag = _jobDbContext.Tags.Select(t => new TagBlogModel
            {
                Id = t.Id,
                IsActive = t.IsActive,
                Name = t.Name,
                Order = t.Order,
                Blogs = t.Blogs.Select(b => new ArticleModel
                {
                    ShortDescription = b.ShortDescription,
                    Description = b.Description,
                    Id = b.Id,
                    ImagePath = b.ImagePath,
                    isActive = b.isActive,
                    PublishDate = b.PublishDate,
                    isPopular = b.isPopular,
                    Order = b.Order,
                    Title = b.Title,
                    WrittenDate = b.WrittenDate,
                }).ToList()
            }).FirstOrDefault(f => f.Id == id);

            TagValidator validator = new TagValidator();
            ValidationResult result = validator.Validate(tagModel);

            if (result.IsValid)
            {
                var allTags = _jobDbContext.Tags.ToList();
                var editableTag = _jobDbContext.Tags.Find(tagModel.Id);
                foreach (var article in allTags)
                {
                    if (tagModel.Order == article.Order)
                    {
                        article.Order = editableTag.Order;
                    }
                }

                if (tagModel.Order == null || tagModel.Order == 0)
                {
                    tagModel.Order = allTags.Count() + 1;
                }

                _jobDbContext.Entry(editableTag).CurrentValues.SetValues(tagModel);
                _jobDbContext.SaveChanges();
                TempData["EditingTag"] = "Thank you";
                return RedirectToAction("Tag", "Home");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(tag);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TagBlogModel tagModel)
        {
            Tag tag = new Tag
            {
                Id = tagModel.Id,
                IsActive = tagModel.IsActive,
                Name = tagModel.Name,
                Order = tagModel.Order
            };
            _jobDbContext.Tags.Add(tag);
            _jobDbContext.SaveChanges();

            return RedirectToAction("Tag","Home");
        }

        public ActionResult Delete(int id)
        {
            var deletedTag = _jobDbContext.Tags.Find(id);

            if (deletedTag == null)
            {
                return HttpNotFound();
            }
            else
            {
                _jobDbContext.Tags.Remove(deletedTag);
                _jobDbContext.SaveChanges();
                TempData["DeleteTag"] = "Deleted";
                return RedirectToAction("Tag", "Home");
            }
        }
    }
}