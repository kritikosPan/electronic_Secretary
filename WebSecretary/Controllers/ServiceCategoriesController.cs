using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using MyDatabase;

namespace WebSecretary.Controllers
{
    public class ServiceCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceCategories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: ServiceCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCategory serviceCategory = db.Categories.Find(id);
            if (serviceCategory == null)
            {
                return HttpNotFound();
            }
            return View(serviceCategory);
        }

        // GET: ServiceCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceCategoryId,Category")] ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(serviceCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceCategory);
        }

        // GET: ServiceCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCategory serviceCategory = db.Categories.Find(id);
            if (serviceCategory == null)
            {
                return HttpNotFound();
            }
            return View(serviceCategory);
        }

        // POST: ServiceCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceCategoryId,Category")] ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceCategory);
        }

        // GET: ServiceCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCategory serviceCategory = db.Categories.Find(id);
            if (serviceCategory == null)
            {
                return HttpNotFound();
            }
            return View(serviceCategory);
        }

        // POST: ServiceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceCategory serviceCategory = db.Categories.Find(id);
            db.Categories.Remove(serviceCategory);
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
