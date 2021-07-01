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
    public class CandidateController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public CandidateController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Candidate
        public PartialViewResult Candidates()
        {
            return PartialView(_jobDbContext.GetCandidates());
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var candidate = await _jobDbContext.GetCandidateDetailAsync(id);

            if (candidate == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(candidate);
        }
    }
}