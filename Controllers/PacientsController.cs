using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication12.DAL;
using WebApplication12.ViewModels;
using AutoMapper;
using System.Data.Entity.Validation;
using WebApplication12.Models;

namespace WebApplication11.Controllers
{
    public  class PacientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pacients
        public ActionResult Index(string searching)
        {
           
            var pacients = db.Pacients.ToList().Where(c => c.DoctorId == User.Identity.GetUserId());


            var search_pacient = pacients;
            if (searching == null) { }

                else
                search_pacient = pacients.Where(c => c.Name.Contains(searching)).ToList();



            var pacientVm = Mapper.Map<IEnumerable<PacientDetailsVm>>(search_pacient);
            return View(pacientVm);
            //return View()
        }
        public ActionResult Search(string searching)
        {
            return View(db.Pacients.Where(x=>x.Name.Contains(searching) || searching == null).ToList());
        }
        // GET: Pacients/Details/5
        public  ActionResult Details(string id)
        {
          


            var pacient = db.Pacients.FirstOrDefault(x => x.Id == id);




            var ls = db.DietMeals.Where(c => c.DietId == pacient.Diet.DietId).ToList();
            List<Meal> meals = new List<Meal>();


            foreach (var item in ls)
            {
                var it = db.Meals.Find(item.MealId);
                meals.Add(it);
            }
            pacient.Diet.Meals = meals;
            // pacient.Diet.Meals = db.Meals.Where(c=>c.DietId==pacient.Diet.DietId).ToList();

            var  pacientVM = Mapper.Map<PacientDetailsVm>(pacient);
            

            return View(pacientVM);

        }

       public ActionResult EditPacient(string id)
        {

            Pacient pacient = db.Pacients.Find(id);
            var pacientVM = Mapper.Map<PacientDetailsVm>(pacient);


            return View(pacientVM);    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPacient(PacientDetailsVm pacient)
        {

            Pacient pacien = new Pacient() ;
            pacien = db.Pacients.Find(pacient.Id);
            pacien.Height = pacient.Height;
            pacien.Age = pacient.Age;
            pacien.Unlike = pacient.Unlike;
            pacien.Alergic = pacient.Alergic;
            pacien.Сontraindication = pacient.EatNo;
            pacien.LifeType = pacient.LifeType;
            pacien.TargetWeight = pacient.TargetWeight;
            pacien.ConsultationCount = pacient.ConsultationCount;

            if (ModelState.IsValid)
            {
                db.Entry(pacien).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Details" , new { id = pacien.Id});
            }
           
            return View(pacient);
        }
        // GET: Pacients/Create
      

        // GET: Pacients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,DoctorId,CreationDate,DietDurationDays,CurrentDietName,ConsultationCount,TargetWeight")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacient);
        }

        // GET: Pacients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pacient pacient = db.Pacients.Find(id);
            db.Users.Remove(pacient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
