using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication12.Models;

namespace WebApplication12.ViewModels
{
    public class DietDetailsVm
    {


        public string DietId { get; set; }

        public string Name { get; set; }

        public string DataCreate { get; set; }

        public int AddMeals { get; set; }

        public int CountPacients { get; set; }




        public List<Meal> Meals { get; set; }
        public List<Pacient> ForPacients { get; set; }
    }
}