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
    public class MenuController : Controller
    {
        private readonly JobDbContext _jobDbContext;

        public MenuController()
        {
            _jobDbContext = new JobDbContext();
        }
        // GET: Menu
        public PartialViewResult Menus()
        {
            return PartialView(_jobDbContext.AllMenus());
        }
    }
}