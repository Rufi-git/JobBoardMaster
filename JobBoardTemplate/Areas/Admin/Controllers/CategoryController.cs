using FluentValidation.Results;
using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Areas.Admin.Validators;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public CategoryController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Admin/Category
        [HttpGet]
        public ViewResult EditCategoryJob(int id)
        {
            var category = _jobDbContext.EditAdminCategoryJob(id);
            TempData["CategoryId"] = category.Id;
            TempData["CategoryJobId"] = category.Id;
            ViewBag.JobEdit = TempData["JobEditing"];
            ViewBag.JobDelete = TempData["JobDelete"];
            ViewBag.AddedJob = TempData["AddedJob"];

            return View(category);
        }


        [HttpPost]
        public ActionResult EditCategoryJob(int id, CategoryModel categoryModel)
        {
            var category = _jobDbContext.EditAdminCategoryJob(id);

            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(categoryModel);

            if (result.IsValid)
            {
                var editableCategory = _jobDbContext.CategoryJobs.Find(categoryModel.Id);
                var allCategories = _jobDbContext.CategoryJobs.ToList();

                //foreach (var category in allCategories)
                //{
                //    if (editableCategory.Order == category.Order)
                //    {
                //        category.Order = editableCategory.Order;
                //    }
                //}

                _jobDbContext.Entry(editableCategory).CurrentValues.SetValues(categoryModel);

                _jobDbContext.SaveChanges();
                //TempData["Editing"] = "Thank you";
                return RedirectToAction("Category", "Home");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(category);
        }

        [HttpGet]
        public ViewResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryModel categoryModel)
        {
            CategoryJob category = new CategoryJob
            {
                Id = categoryModel.Id,
                IsActive = categoryModel.IsActive,
                IsPopular = categoryModel.IsPopular,
                Name = categoryModel.Name,
                Order = categoryModel.Order
            };
            _jobDbContext.CategoryJobs.Add(category);
            _jobDbContext.SaveChanges();
            return RedirectToAction("Category","Home");
        }

        public ActionResult Delete(int id)
        {
            var deletedCategory = _jobDbContext.CategoryJobs.Find(id);

            if (deletedCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                _jobDbContext.CategoryJobs.Remove(deletedCategory);
                _jobDbContext.SaveChanges();
                //TempData["Delete"] = "Deleted";
                return RedirectToAction("Category", "Home");
            }
        }
    }
}