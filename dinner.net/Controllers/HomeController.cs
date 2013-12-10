using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dinner.net.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "dinner.net is my example project to learn ASP.NET MVC";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Looking to add a new software developer to your team?";

            return View();
        }
    }
}