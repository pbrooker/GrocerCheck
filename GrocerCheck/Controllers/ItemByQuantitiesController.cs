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

namespace GrocerCheck.Controllers
{
    public class ItemByQuantitiesController : Controller
    {
        private GrocerCheckContext db = new GrocerCheckContext();

        // GET: ItemByQuantities
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: ItemByQuantities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemByQuantity itemByQuantity = db.ItemsByQuantity.Find(id);
            if (itemByQuantity == null)
            {
                return HttpNotFound();
            }
            return View(itemByQuantity);
        }

        // GET: ItemByQuantities/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.GrocerID = new SelectList(db.Grocers, "GrocerID", "GrocerName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeDescription");
            return View();
        }

        // POST: ItemByQuantities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemName,BrandID,GrocerID,CategoryID,SizeID,StandardIdent,Price,Updated,Quantity,CalculatedPrice")] ItemByQuantity itemByQuantity)
        {
            

            if (ModelState.IsValid)
            {
                db.Items.Add(itemByQuantity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemByQuantity);
        }

        // GET: ItemByQuantities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemByQuantity itemByQuantity = db.ItemsByQuantity.Find(id);
            if (itemByQuantity == null)
            {
                return HttpNotFound();
            }
            return View(itemByQuantity);
        }

        // POST: ItemByQuantities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,BrandID,GrocerID,CategoryID,SizeID,StandardIdent,Price,Updated,Quantity,CalculatedPrice")] ItemByQuantity itemByQuantity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemByQuantity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemByQuantity);
        }

        // GET: ItemByQuantities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemByQuantity itemByQuantity = db.ItemsByQuantity.Find(id);
            if (itemByQuantity == null)
            {
                return HttpNotFound();
            }
            return View(itemByQuantity);
        }

        // POST: ItemByQuantities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemByQuantity itemByQuantity = db.ItemsByQuantity.Find(id);
            db.Items.Remove(itemByQuantity);
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
