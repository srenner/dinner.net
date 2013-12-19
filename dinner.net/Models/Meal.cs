using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dinner.net.Models
{
    public class Meal
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage="Meal must have a name")]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Display(Name = "Extended Description")]
        public string ExtendedDescription { get; set; }

        public virtual ICollection<MealIngredient> Ingredients { get; set; }

        [Display(Name = "Steps to make")]
        public string StepsToMake { get; set; }

        [Display(Name = "Rating 1-10")]
        public int Rating { get; set; }
        
        public DateTime LastAte { get; set; }
    }
}