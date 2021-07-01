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
    public class CompanyController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public CompanyController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Company
        public ViewResult TopCompanies()
        {
            return View(_jobDbContext.GetTopCompanies());
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var company = await _jobDbContext.GetCompanyDetailAsync(id);

            if(company == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(company);
        }

        public ActionResult Companies()
        {
            var companies = _jobDbContext.Companies.Take(4).Select(s => new CompanyModel
            {
                Id = s.Id,
                ImagePath = s.ImagePath,
                Name = s.Name
            }).ToList();
            return View(companies);
        }
    }
}