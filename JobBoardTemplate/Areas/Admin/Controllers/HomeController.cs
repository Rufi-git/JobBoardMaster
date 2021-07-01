using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public HomeController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            var allBlogs = _jobDbContext.Blogs.OrderBy(x => x.Order).ToList();
            ViewBag.Editing = TempData["Editing"] as string;
            ViewBag.Delete = TempData["Delete"] as string;
            ViewBag.Added = TempData["Added"] as string;
            if (Session["adminUser"] != null)
            {
                Session.Timeout = 7200;
                return View(allBlogs);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Category()
        {
            return View(_jobDbContext.CategoryJobs.OrderBy(x => x.Order).ToList());
        }

        public async Task<ActionResult> Tag()
        {
            var tags = await _jobDbContext.AdminTag();
            ViewBag.EditingTag = TempData["EditingTag"];
            ViewBag.DeleteTag = TempData["DeleteTag"];
            return View(tags);
        }
    }
}