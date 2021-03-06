﻿using dinner.net.DAL;
using dinner.net.Models;
using dinner.net.ViewModels;
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
            List<Meal> allMeals;
            using (var context = new DinnerContext())
            {
                allMeals = context.Meals.OrderBy(x => x.Name).ToList();
            }
            return View(new HomeView() { AllMeals = allMeals });
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