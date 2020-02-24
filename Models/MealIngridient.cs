using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class MealIngridient
    {
        public string IngridientId { get; set; }
        
        public string MealId { get; set; }
        [ForeignKey("IngridientId")]
        public virtual Ingredient Ingredient { get; set; }
        [ForeignKey("MealId")]
        public virtual Meal Meal { get; set; }

    }
}