using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Doctor:ApplicationUser
    {
        public List<Pacient> Pacients { get; set; }
    }
}