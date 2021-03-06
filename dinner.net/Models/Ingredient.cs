﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dinner.net.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.MealIngredients = new HashSet<MealIngredient>();
        }

        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name="Extended Description")]
        public string ExtendedDescription { get; set; }

        [Display(Name="Quantity on Hand")]
        public int? QuantityOnHand { get; set; }

        public virtual ICollection<MealIngredient> MealIngredients { get; set; }


        public override string ToString()
        {
            return "[Ingredient] " + this.Name;
        }
    }
}