using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Ingredient
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Ingredient(string i,string n,string d)
        {
            Id = i;
            Name = n;
            Description = d;
        }

        public List<MealIngridient> MealIngridients { get; set; }

    }
}