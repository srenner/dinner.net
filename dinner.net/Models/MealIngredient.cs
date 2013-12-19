using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dinner.net.Models
{
    public class MealIngredient
    {
        public int ID { get; set; }

        public int MealID { get; set; }
        public int IngredientID { get; set; }

        public int Quantity { get; set; }
        public string QuantityDescription { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Meal Meal { get; set; }

    }
}