using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dinner.net.Models
{
    public class MealIngredient
    {
        public int ID { get; set; }

        public Meal Meal { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Quantity { get; set; }
        public string QuantityDescription { get; set; }
    }
}