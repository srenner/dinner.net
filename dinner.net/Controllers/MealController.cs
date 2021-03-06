﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dinner.net.Models;
using dinner.net.DAL;

namespace dinner.net.Controllers
{
    public class MealController : Controller
    {
        private DinnerContext db = new DinnerContext();

        // GET: /Meal/
        public async Task<ActionResult> Index()
        {
            return View(await db.Meals.ToListAsync());
        }

        // GET: /Meal/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: /Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Meal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,ExtendedDescription,StepsToMake,Rating,Cost,Effort, LastAte")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Meals.Add(meal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        // GET: /Meal/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: /Meal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Name,ExtendedDescription,StepsToMake,Rating,Cost,Effort,LastAte,Ingredients")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // GET: /Meal/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: /Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Meal meal = await db.Meals.FindAsync(id);
            db.Meals.Remove(meal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: /Meal/AddHistory/5
        [HttpPost]
        public void AddHistory(int id, DateTime dateAte)
        {
            Meal meal = db.Meals.Find(id);
            meal.LastAte = dateAte;

            MealHistory history = new MealHistory();
            history.MealID = id;
            history.DateAte = dateAte;
            db.MealHistory.Add(history);

            db.SaveChanges();

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
