using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly JobDbContext _jobDbContext;
        public AccountController()
        {
            _jobDbContext = new JobDbContext();
        }

        // GET: Admin/Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AdminAccount adminAccount = _jobDbContext.AdminAccounts.UserExists(loginModel);

                if (adminAccount == null)
                {
                    ModelState.AddModelError("", "Username and Password is invalid");
                    return View();
                }
                else
                {
                    Session.Add("adminUser", adminAccount.Id);
                    Response.Cookies.Add(new HttpCookie("adminCookie")
                    {
                        Expires = DateTime.Now.AddHours(5),
                        Value = "My Admin Cookie"
                    });
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Signout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}