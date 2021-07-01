using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Controllers
{
    public class BlogController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        private int _itemsPerPage = 4;
        public BlogController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Blog
        [ActionName("Articles")]
        public PartialViewResult ArticlesPerPage(int id = 1)
        {
            return PartialView(_jobDbContext.GetArticles(id, _itemsPerPage));
        }

        public PartialViewResult GetAllArticles()
        {
            return PartialView(_jobDbContext.Blogs.ToList());
        }

        public PartialViewResult Categories()
        {
            return PartialView(_jobDbContext.GetCategoryBlogs());
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var article = await _jobDbContext.GetBlogDetailAsync(id);
            if(article == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return PartialView(article);
        }

        public PartialViewResult PopularArticles()
        {
            return PartialView(_jobDbContext.GetPopularBlogs());
        }

        public PartialViewResult Feeds()
        {
            return PartialView(_jobDbContext.GetFeeds());
        }
    }
}