using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Meal
    {
        [Key]
        public string MealId { get; set; }
        public string Name { get; set; }
        public string DataAdd { get; set; }
        public string TypeMeals { get; set; }
        public Color MealColor { get; set; }
        public Meal(string mealId, string name,Color mealColor)
        {
            this.MealId = mealId;
            this.Name = name;
            this.MealColor = mealColor;
        }

        public Meal()
        {
            
        }


        public List<Ingredient> Ingridients { get; set; }
        public List<Schedule> Schedules { get; set; }

    }
}