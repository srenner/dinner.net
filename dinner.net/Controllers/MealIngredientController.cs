using System;
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
    public class MealIngredientController : Controller
    {
        private DinnerContext db = new DinnerContext();

        // GET: /MealIngredient/
        public async Task<ActionResult> Index()
        {
            var mealingredients = db.MealIngredients.Include(m => m.Ingredient).Include(m => m.Meal);
            return View(await mealingredients.ToListAsync());
        }

        // GET: /MealIngredient/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngredient mealingredient = await db.MealIngredients.FindAsync(id);
            if (mealingredient == null)
            {
                return HttpNotFound();
            }
            return View(mealingredient);
        }

        // GET: /MealIngredient/Create
        public ActionResult Create()
        {
            ViewBag.IngredientID = new SelectList(db.Ingredients, "ID", "Name");
            ViewBag.MealID = new SelectList(db.Meals, "ID", "Name");
            return View();
        }

        // POST: /MealIngredient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,MealID,IngredientID,Quantity,QuantityDescription")] MealIngredient mealingredient)
        {
            if (ModelState.IsValid)
            {
                db.MealIngredients.Add(mealingredient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IngredientID = new SelectList(db.Ingredients, "ID", "Name", mealingredient.IngredientID);
            ViewBag.MealID = new SelectList(db.Meals, "ID", "Name", mealingredient.MealID);
            return View(mealingredient);
        }

        // GET: /MealIngredient/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngredient mealingredient = await db.MealIngredients.FindAsync(id);
            if (mealingredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "ID", "Name", mealingredient.IngredientID);
            ViewBag.MealID = new SelectList(db.Meals, "ID", "Name", mealingredient.MealID);
            return View(mealingredient);
        }

        // POST: /MealIngredient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,MealID,IngredientID,Quantity,QuantityDescription")] MealIngredient mealingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealingredient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "ID", "Name", mealingredient.IngredientID);
            ViewBag.MealID = new SelectList(db.Meals, "ID", "Name", mealingredient.MealID);
            return View(mealingredient);
        }

        // GET: /MealIngredient/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngredient mealingredient = await db.MealIngredients.FindAsync(id);
            if (mealingredient == null)
            {
                return HttpNotFound();
            }
            return View(mealingredient);
        }

        // POST: /MealIngredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MealIngredient mealingredient = await db.MealIngredients.FindAsync(id);
            db.MealIngredients.Remove(mealingredient);
            await db.SaveChangesAsync();
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
