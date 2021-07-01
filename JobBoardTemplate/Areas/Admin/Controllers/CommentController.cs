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
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public CommentController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Admin/Comment
        public ActionResult Delete(int id)
        {
            var deletedComment = _jobDbContext.Comments.Find(id);

            if (deletedComment == null)
            {
                return HttpNotFound();
            }
            else
            {
                _jobDbContext.Comments.Remove(deletedComment);
                _jobDbContext.SaveChanges();
                TempData["DeleteComment"] = "Deleted";
                ViewBag.ArticleId = TempData["ArticleId"] as int?;
                return RedirectToAction("EditBlog", "Blog", routeValues: new { Id = ViewBag.ArticleId });
            }
        }

        public ActionResult CommentNotInBlog(int id)
        {
            var comments = _jobDbContext.AdminCommentNotInBlog(id);
            return View(comments);
        }

        [HttpGet]
        public async Task<ActionResult> EditComment(int id)
        { 
            var comment = await _jobDbContext.EditAdminCommentGet(id);
            if (comment == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(comment);
        }

        [HttpPost]
        public ActionResult EditComment(CommentBlogModel commentModel)
        {
            CommentValidator validator = new CommentValidator();
            ValidationResult result = validator.Validate(commentModel);

            if (result.IsValid)
            {
                if (commentModel.ImageFile != null)
                {
                    commentModel.ImagePath = Seo.MakeTheFileName(commentModel.ImageFile.FileName);
                    commentModel.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img/users/"), Path.GetFileName(commentModel.ImagePath)));
                }
                _jobDbContext.EditAdminCommentPost(commentModel);
                ViewBag.ArticleId = TempData["ArticleId"] as int?;
                TempData["Edit"] = "Edited";

                return RedirectToAction("EditBlog", "Blog", routeValues: new { Id = ViewBag.ArticleId });
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(commentModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CommentBlogModel commentModel)
        {
            CommentValidator validator = new CommentValidator();
            ValidationResult result = validator.Validate(commentModel);

            if (result.IsValid)
            {
                if (commentModel.ImageFile != null)
                {
                    commentModel.ImagePath = Seo.MakeTheFileName(commentModel.ImageFile.FileName);
                    commentModel.ImageFile.SaveAs(Path.Combine(Server.MapPath("/Content/img/users/"), Path.GetFileName(commentModel.ImagePath)));
                }
                commentModel.BlogId = Convert.ToInt32(TempData["ArticleId"]);
                _jobDbContext.AdminCommentAdd(commentModel);

                TempData["AddedComment"] = "Added";
                ViewBag.ArticleId = TempData["ArticleId"] as int?;
                return RedirectToAction("EditBlog", "Blog", routeValues: new { Id = ViewBag.ArticleId });
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(commentModel);
        }
    }
}