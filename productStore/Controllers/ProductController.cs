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
    public class ProductController : Controller
    {
        private ProductStoreEntities db = new ProductStoreEntities();

        // GET: Product
        public ActionResult Index()
        {
            var tbl_product = db.tbl_product.Include(t => t.tbl_brands).Include(t => t.tbl_category);
            return View(tbl_product.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.product_brand = new SelectList(db.tbl_brands, "brand_id", "brand_name");
            ViewBag.product_cat = new SelectList(db.tbl_category, "cat_id", "cat_name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,product_name,product_qty,product_price,product_cat,product_brand")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.tbl_product.Add(tbl_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_brand = new SelectList(db.tbl_brands, "brand_id", "brand_name", tbl_product.product_brand);
            ViewBag.product_cat = new SelectList(db.tbl_category, "cat_id", "cat_name", tbl_product.product_cat);
            return View(tbl_product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_brand = new SelectList(db.tbl_brands, "brand_id", "brand_name", tbl_product.product_brand);
            ViewBag.product_cat = new SelectList(db.tbl_category, "cat_id", "cat_name", tbl_product.product_cat);
            return View(tbl_product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,product_qty,product_price,product_cat,product_brand")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_brand = new SelectList(db.tbl_brands, "brand_id", "brand_name", tbl_product.product_brand);
            ViewBag.product_cat = new SelectList(db.tbl_category, "cat_id", "cat_name", tbl_product.product_cat);
            return View(tbl_product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            db.tbl_product.Remove(tbl_product);
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
