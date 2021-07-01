using FluentValidation.Results;
using JobBoardTemplate.AppCode;
using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Areas.Admin.Validators;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class JobController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public JobController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Admin/Job
        public ActionResult Delete(int id)
        {
            var deletedJob = _jobDbContext.Jobs.Find(id);

            if (deletedJob == null)
            {
                return HttpNotFound();
            }
            else
            {
                int idCat = Convert.ToInt32(TempData["CategoryId"]);
                CategoryJob categoryJob = _jobDbContext.CategoryJobs.FirstOrDefault(x => x.Id == idCat);
                _jobDbContext.Jobs.Remove(deletedJob);
                _jobDbContext.SaveChanges();
                ViewBag.CategoryId = TempData["CategoryId"] as int?;
                TempData["JobDelete"] = "Thank you!!";
                return RedirectToAction("EditCategoryJob", "Category", routeValues: new { Id = ViewBag.CategoryId });
            }
        }

        [HttpGet]
        public ActionResult EditJob(int id)
        {
            var job = _jobDbContext.Jobs.Select(j => new JobCategoryModel
            {
                Id = j.Id,
                Description = j.Description,
                SalaryFrom = j.SalaryFrom,
                SalaryTo = j.SalaryTo,
                ExpireDate = j.ExpireDate,
                PublisDate = j.PublisDate,
                WorkDuration = j.WorkDuration,
                Benefits = j.Benefits,
                ImagePath = j.ImagePath,
                IsActive = j.IsActive,
                Location = j.Location,
                Name = j.Name,
                Order = j.Order,
                Qualifications = j.Qualifications,
                Responsibility = j.Responsibility,
                Vacancy = j.Vacancy
            }).FirstOrDefault(x => x.Id == id);
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJob(JobCategoryModel jobCategoryModel, int id)
        {
            JobValidator validator = new JobValidator();
            ValidationResult result = validator.Validate(jobCategoryModel);
            if (result.IsValid)
            {

                var allJobs = _jobDbContext.Jobs.ToList();
                var editableJob = _jobDbContext.Jobs.Find(id);
                foreach (var job in allJobs)
                {
                    if (jobCategoryModel.Order == job.Order)
                    {
                        job.Order = editableJob.Order;
                    }
                }

                if (jobCategoryModel.Image != null)
                {
                    jobCategoryModel.ImagePath = Seo.MakeTheFileName(jobCategoryModel.Image.FileName);
                    jobCategoryModel.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/svg_icon/"), Path.GetFileName(jobCategoryModel.ImagePath)));
                }
                _jobDbContext.EditAdminJob(jobCategoryModel);
                TempData["JobEditing"] = "Thank you";
                ViewBag.CategoryJobId = TempData["CategoryJobId"] as int?;
                return RedirectToAction("EditCategoryJob", "Category", routeValues: new { Id = ViewBag.CategoryJobId });
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(jobCategoryModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(JobCategoryModel jobCategoryModel)
        {
            JobValidator validator = new JobValidator();
            ValidationResult result = validator.Validate(jobCategoryModel);
            if (result.IsValid)
            {
                var allJobs = _jobDbContext.Jobs.ToList();
                //if (jobCategoryModel.Image != null)
                //{
                //    articleModel.ImagePath = Seo.MakeTheFileName(articleModel.Image.FileName);
                //    articleModel.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/blog/"), Path.GetFileName(articleModel.ImagePath)));
                //}
                if (jobCategoryModel.Image != null)
                {
                    jobCategoryModel.ImagePath = Seo.MakeTheFileName(jobCategoryModel.Image.FileName);
                    jobCategoryModel.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/svg_icon/"), Path.GetFileName(jobCategoryModel.ImagePath)));
                }
                jobCategoryModel.PublisDate = DateTime.Now;
                jobCategoryModel.ExpireDate = DateTime.Now;

                var job = _jobDbContext.AddAdminJob(jobCategoryModel);

                if (job.Order == null || job.Order == 0)
                {
                    job.Order = allJobs.Count() + 1;
                }

                ViewBag.CategoryId = TempData["CategoryId"] as int?;
                int id = ViewBag.CategoryId;
                CategoryJob categoryJob = _jobDbContext.CategoryJobs.FirstOrDefault(x => x.Id == id);
                _jobDbContext.Jobs.Add(job).CategoryJobs.Add(categoryJob);
                _jobDbContext.SaveChanges();
                TempData["AddedJob"] = "Added";

                return RedirectToAction("EditCategoryJob", "Category", routeValues: new { Id = id });
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }

            return View(jobCategoryModel);
        }

        //public ActionResult JobsNotInCategory(int id)
        //{
        //    var category = _jobDbContext.CategoryJobs.Include("Jobs").Select(f => new CategoryModel
        //    {
        //        Id = f.Id,
        //        IsActive = f.IsActive,
        //        IsPopular = f.IsPopular,
        //        Name = f.Name,
        //        Order = f.Order,
        //        Jobs = f.Jobs.Select(j => new JobCategoryModel
        //        {
        //            Id = j.Id,
        //            ImagePath = j.ImagePath,
        //            Location = j.Location,
        //            PublisDate = j.PublisDate,
        //            WorkDuration = j.WorkDuration,
        //            Name = j.Name,
        //            ExpireDate = j.ExpireDate,
        //            IsActive = j.IsActive,
        //            Order = j.Order,
        //            SalaryFrom = j.SalaryFrom,
        //            SalaryTo = j.SalaryTo,
        //            Benefits = j.Benefits,
        //            Description = j.Description,
        //            Qualifications = j.Qualifications,
        //            Responsibility = j.Responsibility,
        //            Vacancy = j.Vacancy
        //        }).ToList()
        //    }).FirstOrDefault(x => x.Id == id);

        //    return View(category);
        //}
    }
}