using FluentValidation.Results;
using JobBoardTemplate.AppCode;
using JobBoardTemplate.Data;
using JobBoardTemplate.Infrastructure;
using JobBoardTemplate.Models;
using JobBoardTemplate.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardTemplate.Controllers
{
    public class AccountController : Controller
    {
        private readonly JobDbContext _jobDbContext;

        public AccountController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Register = TempData["Register"] as string;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel register)
        {
            RegisterValidator validator = new RegisterValidator();
            ValidationResult validationResult = validator.Validate(register);

            if (validationResult.IsValid)
            {
                if (register.Image != null)
                {
                    register.ImagePath = Seo.MakeTheFileName(register.Image.FileName);
                    register.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/users/"), Path.GetFileName(register.ImagePath)));
                }
                _jobDbContext.AccountRegister(register);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var failure in validationResult.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(register);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginAccountModel login)
        {
            LoginValidator validator = new LoginValidator();
            ValidationResult result = validator.Validate(login);

            var allUsers = _jobDbContext.AppUsers.ToList();
            if (result.IsValid)
            {
                AppUser appUser = allUsers.Where(user => user.UserName == login.UserName && user.Password == login.Password).SingleOrDefault();

                if (appUser != null)
                {
                    Session.Add("UserSession", appUser.Id);
                    List<AppUser> userInfo = new List<AppUser>();
                    userInfo.Add(new AppUser()
                    {
                        Name = appUser.Name,
                        Surname = appUser.Surname,
                        AboutMe = appUser.AboutMe,
                        Age = appUser.Age,
                        Email = appUser.Email,
                        Gender = appUser.Gender,
                        Id = appUser.Id,
                        ImagePath = appUser.ImagePath,
                        Password = appUser.Password,
                        Review = appUser.Review,
                        UserName = appUser.UserName
                    });
                    foreach (var user in userInfo)
                    {
                        HttpCookie userName = new HttpCookie("userName", user.Name);
                        Response.Cookies.Add(userName);

                        HttpCookie userSurname = new HttpCookie("userSurname", user.Surname);
                        Response.Cookies.Add(userSurname);

                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is invalid");
                    return View();
                }
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Testimonial()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Testimonial(RegisterModel register)
        {
            RegisterValidator validator = new RegisterValidator();
            ValidationResult validationResult = validator.Validate(register);
            
            if (validationResult.IsValid)
            {
                if (register.Image != null)
                {
                    register.ImagePath = Seo.MakeTheFileName(register.Image.FileName);
                    register.Image.SaveAs(Path.Combine(Server.MapPath("/Content/img/users/"), Path.GetFileName(register.ImagePath)));
                }
                _jobDbContext.AccountRegister(register);
                return RedirectToAction("Login", "Account");
            }
            return View(register);
        }
    }
}