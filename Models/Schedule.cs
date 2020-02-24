using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Schedule
    {
        public string Id { get; set;}
        [ForeignKey("Diet")]
        public string DietId { get; set; }
        [ForeignKey("Meal")]
        public string MealId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan MealTime { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual Diet Diet { get; set; } 

    }
}