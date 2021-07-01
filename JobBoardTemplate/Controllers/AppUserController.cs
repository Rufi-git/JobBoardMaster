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
    public class AppUserController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public AppUserController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: AppUser
        public PartialViewResult Testimonial()
        {
            return PartialView(_jobDbContext.GetTestimonialUsers());
        }
    }
}