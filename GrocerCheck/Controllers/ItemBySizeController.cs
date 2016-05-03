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
    public class ItemBySizeController : Controller
    {
        private GrocerCheckContext db = new GrocerCheckContext();

        // GET: ItemBySize
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: ItemBySize/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBySize itemBySize = db.ItemsBySize.Find(id);
            if (itemBySize == null)
            {
                return HttpNotFound();
            }
            return View(itemBySize);
        }

        // GET: ItemBySize/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.GrocerID = new SelectList(db.Grocers, "GrocerID", "GrocerName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeDescription");
            return View();
        }

        // POST: ItemBySize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,BrandID,GrocerID,CategoryID,SizeID,StandardIdent,Price,Updated,Size,SizeType,CalculatedPrice")] ItemBySize itemBySize)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(itemBySize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemBySize);
        }

        // GET: ItemBySize/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBySize itemBySize = db.ItemsBySize.Find(id);
            if (itemBySize == null)
            {
                return HttpNotFound();
            }
            return View(itemBySize);
        }

        // POST: ItemBySize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,BrandID,GrocerID,CategoryID,SizeID,StandardIdent,Price,Updated,Size,SizeType,CalculatedPrice")] ItemBySize itemBySize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemBySize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemBySize);
        }

        // GET: ItemBySize/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBySize itemBySize = db.ItemsBySize.Find(id);
            if (itemBySize == null)
            {
                return HttpNotFound();
            }
            return View(itemBySize);
        }

        // POST: ItemBySize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemBySize itemBySize = db.ItemsBySize.Find(id);
            db.Items.Remove(itemBySize);
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
