using dinner.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dinner.net.ViewModels
{
    public class HomeView
    {
        public List<Meal> AllMeals { get; set; }
        public List<Meal> RecentMeals { get; set; }
    }
}