using FluentValidation.Results;
using JobBoardTemplate.AppCode;
using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Areas.Admin.Validators;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public BlogController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Admin/Edit
        [HttpGet]
        [ActionName("EditBlog")]
        public async Task<ActionResult> EditBlogAsync(int id)
        {
            var singleBlog = await _jobDbContext.EditBlogAsync(id);

            if (singleBlog == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }

            TempData["ArticleId"] = singleBlog.Id;
            ViewBag.DeleteComment = TempData["DeleteComment"] as string;
            ViewBag.Edit = TempData["Edit"] as string;
            ViewBag.AddedComment = TempData["AddedComment"] as string;
            return View(singleBlog);
        }

        [HttpPost]
        [ActionName("EditBlog")]
        public async Task<ActionResult> EditBlogAsync(int id, ArticleModel articleModel)
        {
            var singleBlog = await _jobDbContext.EditBlogAsync(id);
            BlogValidator validator = new BlogValidator();
            ValidationResult result = validator.Validate(articleModel);
            if (result.IsValid)
            {
                var editableBlog = _jobDbContext.Blogs.Find(articleModel.Id);
                var allArticles = _jobDbContext.Blogs.ToList();

                foreach (var article in allArticles)
                {
                    if (articleModel.Order == article.Order)
                    {
                        article.Order = editableBlog.Order;
                    }
                }

                if (articleModel.Image != null)
                {
                    articleModel.ImagePath = Seo.MakeTheFileName(articleModel.Image.FileName);
                    articleModel.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/blog/"), Path.GetFileName(articleModel.ImagePath)));
                }

                _jobDbContext.Entry(editableBlog).CurrentValues.SetValues(articleModel);
                _jobDbContext.SaveChanges();
                TempData["Editing"] = "Thank you";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(singleBlog);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(ArticleModel articleModel)
        {
            BlogValidator validator = new BlogValidator();
            ValidationResult result = validator.Validate(articleModel);

            if (result.IsValid)
            {
                if (articleModel.Image != null)
                {
                    articleModel.ImagePath = Seo.MakeTheFileName(articleModel.Image.FileName);
                    articleModel.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/blog/"), Path.GetFileName(articleModel.ImagePath)));
                }
                TempData["Added"] = "Added";
                ViewBag.TagId = Convert.ToInt32(TempData["TagId"]);
                int id = ViewBag.TagId;
                _jobDbContext.AddAdminBlog(articleModel, id);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var deletedBlog = _jobDbContext.Blogs.Find(id);
            _jobDbContext.DeleteAdminBlog(id);
            if (deletedBlog == null)
            {
                return HttpNotFound();
            }
            else
            {
                _jobDbContext.Blogs.Remove(deletedBlog);
                _jobDbContext.SaveChanges();
                TempData["Delete"] = "Deleted";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}