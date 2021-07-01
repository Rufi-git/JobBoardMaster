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
    public class JobController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public JobController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Job
        public PartialViewResult AllJobs()
        {
            return PartialView(_jobDbContext.GetAllJobs());
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var job = await _jobDbContext.GetJobDetailAsync(id);
            if (job == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(job);
        }

        public PartialViewResult SliderJob()
        {
            return PartialView(_jobDbContext.GetSliderJob());
        }
    }
}