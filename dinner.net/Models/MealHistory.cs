using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dinner.net.Models
{
    public class MealHistory
    {
        public int ID { get; set; }

        public int MealID { get; set; }

        public DateTime DateAte { get; set; }

        public virtual Meal Meal { get; set; }
    }
}