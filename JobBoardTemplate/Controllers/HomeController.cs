using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public HomeController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Home
        public ViewResult Index()
        {
            HttpCookie userName = Response.Cookies.Get("userName");
            var userNameValue = userName.Value;
            ViewBag.Name = userNameValue;

            HttpCookie userSurname = Response.Cookies.Get("userSurname");
            var userSurnameValue = userSurname.Value;
            ViewBag.Surname = userSurnameValue;
            return View();
        }

        public ViewResult Jobs()
        {
            return View(_jobDbContext.GetAllJobs());
        }

        public ViewResult JobDetails()
        {
            return View();
        }

        public ViewResult Elements()
        {
            return View();

        }

        public ViewResult Candidate()
        {
            return View(_jobDbContext.GetCandidates());
        }

        public ViewResult Blog()
        {
            return View();
        }

        public ViewResult SingleBlog()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View(_jobDbContext.GetContacts());
        }
    }
}