using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Diet
    {
        [Key]
        public string DietId { get; set; }

        public string Name { get; set; }

        public string DataCreate { get; set; }

        public int AddMeals { get; set; }

        public int CountPacients { get; set;}

        public string CurrentDiet { get; set; }


        


        public List<Meal> Meals { get; set; }
        public List<Pacient> ForPacients { get; set; }

    }
}