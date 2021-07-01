using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Controllers
{
    public class CategoryController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public CategoryController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Category
        public ActionResult PopularJobCategories()
        {
            return View(_jobDbContext.GetPopularJobCategories());
        }

        public ActionResult PopularToSearch()
        {
            return View(_jobDbContext.GetPopularToSearch());
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var job = await _jobDbContext.GetCategoryJobDetailAsync(id);

            if (job == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(job);
        }
        [ActionName("DetailsBlog")]
        public async Task<ActionResult> DetailsBlogAsync(int id)
        {
            var blog = await _jobDbContext.GetCategoryBlogDetailAsync(id);

            if (blog == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(blog);
        }
        public ActionResult CategoriesJob()
        {
            var categories = _jobDbContext.CategoryJobs.Take(4).Select(c=>new CategoryJobModel
            {
                Id = c.Id,
                isActive = c.IsActive,
                IsPopular = c.IsPopular,
                Name = c.Name,
                Order = c.Order
            }).ToList();

            return View(categories);
        }
    }
}