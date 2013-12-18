using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dinner.net.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name="Extended Description")]
        public string ExtendedDescription { get; set; }
    }
}