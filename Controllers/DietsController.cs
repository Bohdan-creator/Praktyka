using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication12.DAL;
using WebApplication12.Models;
using WebApplication12.ViewModels;

namespace WebApplication12.Controllers
{
    public class DietsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Diets
        public ActionResult Index(string searching)
        {

            var meals = db.DietMeals.ToList();
            var pacients = db.Pacients.ToList();



            foreach (var item in db.Diets)
            {
                var it = item.DietId;
                var count_meals = meals.Where(x => x.DietId == it).Count();
                var count_pacients = pacients.Where(c => c.DietId == it).Count();
                item.AddMeals = count_meals;
                item.CountPacients = count_pacients;

            }

            

          
            db.SaveChanges();

            var diets = db.Diets.ToList();

            if (searching == null)
            {

            }
            else
            {
                 diets = db.Diets.Where(c=>c.Name.Contains(searching)).ToList();
            }
            var dietVm = Mapper.Map<IEnumerable<DietDetailsVm>>(diets);




            

            return View(dietVm);
        }

        // GET: Diets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = new Diet();
                diet = db.Diets.Find(id);

            var ls = db.DietMeals.Where(c => c.DietId == diet.DietId).ToList();

            List<Meal> meals = new List<Meal>();
            
            foreach (var item in ls)
            { 
                
                var it = db.Meals.Find(item.MealId);
                meals.Add(it);
            }
            diet.Meals = meals;

            var dietVm = Mapper.Map<DietDetailsVm>(diet);

            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(dietVm);
        }

        public ActionResult CreateMeal(string id)
        {

            Diet diet = db.Diets.Find(id);
            Meal meal = new Meal();
       
            var dietVM = Mapper.Map<MealCreateVm>(meal);
            dietVM.DietId = diet.DietId;

            return View(dietVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMeal(MealCreateVm meal)
        {

            foreach(var item in db.Meals)
            {
                if (meal.Name == item.Name)
                {
                    
                    return View("CreateMeal");
                }
            }


            Guid obj = Guid.NewGuid();
            Meal meal_add = new Meal();
            DietMeals dietMeals = new DietMeals();
            //Diet Meal

            dietMeals.Id = obj.ToString();

            obj = Guid.NewGuid();
            meal_add.MealId = obj.ToString();

            dietMeals.DietId = meal.DietId;
            dietMeals.MealId = meal_add.MealId ;

            //Meal
             
            meal_add.Name =meal.Name ;
            meal_add.DataAdd = meal.DataAdd;
            meal_add.TypeMeals = meal.TypeMeals;
            if (ModelState.IsValid)
            {
                db.Meals.Add(meal_add);

                db.DietMeals.Add(dietMeals);

                db.SaveChanges();
                return RedirectToAction("Index", "Diets");
            }


            return View();
        }

        public ActionResult AddMeal()
        {

            ViewBag.DietId = new SelectList(db.Diets, "DietId", "Name");

            ViewBag.MealId = new SelectList(db.Meals, "MealId", "Name");

            var meals = db.Meals.ToList();

            var mealsVm = Mapper.Map<IEnumerable<MealCreateVm>>(meals);


            return View(mealsVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMeal(MealCreateVm meals)
        {

            Guid guid = Guid.NewGuid();

            DietMeals dietMeals = new DietMeals();
            dietMeals.Id = guid.ToString();
            dietMeals.DietId = meals.DietId;
            dietMeals.MealId = meals.MealId;

            return View();
        }



        // GET: Diets/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DietDetailsVm diet)
        {
            Diet diets = new Diet();

            Guid id = Guid.NewGuid();
            diets.DietId = id.ToString();
            diets.Name = diet.Name;
            diets.DataCreate = diet.DataCreate;

            if (ModelState.IsValid)
            {
                db.Diets.Add(diets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diet);
        }

        // GET: Diets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DietId,Name,DataCreate,AddMeals,CountPacients,CurrentDiet")] Diet diet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diet);
        }

        // GET: Diets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Diet diet = db.Diets.Find(id);
            db.Diets.Remove(diet);
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
