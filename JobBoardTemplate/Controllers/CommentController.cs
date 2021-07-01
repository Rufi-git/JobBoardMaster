using FluentValidation.Results;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using JobBoardTemplate.Models;
using JobBoardTemplate.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Controllers
{
    public class CommentController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public CommentController()
        {
            _jobDbContext = new JobDbContext();
        }
        //GET: Comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CommentModel comment)
        {
            if (ModelState.IsValid)
            {
                _jobDbContext.CommentAdd(comment);
                return RedirectToAction("Details", "Blog", new { Id = comment.BlogId });
            }

            return View();
        }
    }
}