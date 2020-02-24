using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using WebApplication12.Models;

namespace WebApplication12.ViewModels
{
    public class MealCreateVm
    {
        [Key]
        public string MealId { get; set; }
        public string Name { get; set; }
        public string DataAdd { get; set; }
        public string TypeMeals { get; set; }
        public Color MealColor { get; set; }
        public string DietId { get; set; }


    }
}