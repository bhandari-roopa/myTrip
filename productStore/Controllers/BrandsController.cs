using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using productStore.Models;

namespace productStore.Controllers
{
    public class BrandsController : Controller
    {
        private ProductStoreEntities db = new ProductStoreEntities();

        // GET: Brands
        public ActionResult Index()
        {
            return View(db.tbl_brands.ToList());
        }

        // GET: Brands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_brands tbl_brands = db.tbl_brands.Find(id);
            if (tbl_brands == null)
            {
                return HttpNotFound();
            }
            return View(tbl_brands);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "brand_id,brand_name")] tbl_brands tbl_brands)
        {
            if (ModelState.IsValid)
            {
                db.tbl_brands.Add(tbl_brands);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_brands);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_brands tbl_brands = db.tbl_brands.Find(id);
            if (tbl_brands == null)
            {
                return HttpNotFound();
            }
            return View(tbl_brands);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "brand_id,brand_name")] tbl_brands tbl_brands)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_brands).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_brands);
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_brands tbl_brands = db.tbl_brands.Find(id);
            if (tbl_brands == null)
            {
                return HttpNotFound();
            }
            return View(tbl_brands);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_brands tbl_brands = db.tbl_brands.Find(id);
            db.tbl_brands.Remove(tbl_brands);
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
