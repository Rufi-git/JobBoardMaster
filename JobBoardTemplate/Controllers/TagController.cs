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
    public class TagController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public TagController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Tag
        public ViewResult Tags()
        {
            return View(_jobDbContext.GetTags());
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var tag = await _jobDbContext.GetTagDetailAsync(id);

            if (tag == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(tag);
        }
    }
}