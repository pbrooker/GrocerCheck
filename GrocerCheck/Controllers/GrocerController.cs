using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrocerCheck.DAL;
using GrocerCheck.Models;
using GrocerCheck.viewModels;

namespace GrocerCheck.Controllers
{
    public class GrocerController : Controller
    {
        private GrocerCheckContext db = new GrocerCheckContext();

        // GET: Grocer
        public ActionResult Index(int? id, int? categoryID, int? BrandID, int? itemID )
        {
            //return View(db.Grocers.ToList());

            //pbrooker: creating multi level list to go from grocer to category to items
            var viewModel = new GrocerIndexData();

            viewModel.Grocers = db.Grocers
                .Include(i => i.Categories)
                .Include(i => i.Brands)
                .Include(i => i.Items)
                .OrderBy(i => i.GrocerName);
            
            //checking for grocer id
            if(id!=null)
            {
                //set Grocer ID in viewbag
                ViewBag.GrocerID = id.Value;

                viewModel.Categories = viewModel.Grocers
                                    .Where(i => i.GrocerID == id.Value).Single().Categories;

                ViewBag.GrocerName = viewModel.Grocers.Where(i => i.GrocerID == id.Value).Single().GrocerName;

            }

            //check for category
            if(categoryID!=null)
            {
                
                ViewBag.CategoryID = categoryID.Value;

                var selectedCategory = viewModel.Categories
                                        .Where(y => y.CategoryID == categoryID.Value)
                                        .Single();
                db.Entry(selectedCategory).Collection(y => y.Brands).Load();
                foreach (Brand brand in selectedCategory.Brands)
                {
                    db.Entry(brand).Reference(y => y.BrandName).Load();
                }
                viewModel.Brands = selectedCategory.Brands;

                ViewBag.CategoryName = selectedCategory.CategoryName;

            }

            if(itemID !=null)
            {
                ViewBag.ItemID = itemID.Value;

                var selectedItem = viewModel.Items
                                    .Where(x => x.ItemID == itemID.Value)
                                    .Single();
                db.Entry(selectedItem).Reference(x => x.item).Load();
               
            }
            return View(viewModel);
        }

        

        // GET: Grocer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocer grocer = db.Grocers.Find(id);
            if (grocer == null)
            {
                return HttpNotFound();
            }
            return View(grocer);
        }

        // GET: Grocer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grocer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrocerID,GrocerName")] Grocer grocer)
        {
            if (ModelState.IsValid)
            {
                db.Grocers.Add(grocer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grocer);
        }

        // GET: Grocer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocer grocer = db.Grocers.Find(id);
            if (grocer == null)
            {
                return HttpNotFound();
            }
            return View(grocer);
        }

        // POST: Grocer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrocerID,GrocerName")] Grocer grocer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grocer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grocer);
        }

        // GET: Grocer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocer grocer = db.Grocers.Find(id);
            if (grocer == null)
            {
                return HttpNotFound();
            }
            return View(grocer);
        }

        // POST: Grocer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grocer grocer = db.Grocers.Find(id);
            db.Grocers.Remove(grocer);
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
