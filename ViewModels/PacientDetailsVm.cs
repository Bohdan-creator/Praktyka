using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication12.Models;
using WebApplication12.ViewModels;

namespace WebApplication12.ViewModels
{
    public  class PacientDetailsVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string DoctorId { get; set; }
        public string DietName { get; set; }
       // public virtual Doctor Doctor { get; set;}
        public string DietID { get; set; }
        public int Age { get; set; }
        public string Alergic { get; set; }
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Diet duration in days interval
        /// </summary>
        /// 
        public string Height { get; set; }
        public string EatNo { get; set; }
        public string Unlike { get; set; }
        public string LifeType { get; set; }
        public string StartWeight { get; set; }


        public int DietDurationDays { get; set; }
        public string CurrentDietName { get; set; }
        public int ConsultationCount { get; set; }
        public string TargetWeight { get; set; }
        public List<Meal> Meals { get; set; }
       // public virtual Diet Diet { get; set; }
        

    }
}