using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class DietMeals
    {
        public string Id { get; set; } 

        public string DietId { get; set; }

        public string MealId { get; set; }

        public virtual Diet Diet { get; set; }

        public virtual Meal Meal { get; set; }

    }
}