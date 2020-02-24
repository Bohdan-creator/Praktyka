using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Pacient:ApplicationUser
    {
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Diet")]
        public string DietId { get; set; }
        public int Age { get; set; }
        public string Alergic { get; set; }
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Diet duration in days interval
        /// </summary>
        public string Height { get; set; }
        public string Сontraindication { get; set; }
        public string Unlike { get; set; }
        public string LifeType { get; set; }
        public string StartWeight { get; set; }

        public int DietDurationDays { get; set; }
        public string CurrentDietName { get; set; }
        public int ConsultationCount { get; set; }
        public string TargetWeight { get; set; }
        public virtual Diet Diet { get; set; }
    }
}