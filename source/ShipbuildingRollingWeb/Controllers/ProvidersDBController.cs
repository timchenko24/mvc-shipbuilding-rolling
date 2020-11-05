using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShipbuildingRollingWeb.Models.DB;

namespace ShipbuildingRollingWeb.Controllers
{
    public class ProvidersDBController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        // GET: ProvidersDB
        public ActionResult Index()
        {
            ViewBag.Admin = User.IsInRole("admin");
            ViewBag.User = User.IsInRole("user");

            return View(db.ProvidersDB.ToList());
        }

        // GET: ProvidersDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidersDB providers = db.ProvidersDB.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            return View(providers);
        }

        // GET: ProvidersDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvidersDB/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address")] ProvidersDB provider)
        {
            if (ModelState.IsValid)
            {
                provider.ID = db.ProvidersDB.ToList().Last().ID + 1;
                db.ProvidersDB.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provider);
        }

        // GET: ProvidersDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidersDB provider = db.ProvidersDB.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: ProvidersDB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address")] ProvidersDB provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        // GET: ProvidersDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidersDB provider = db.ProvidersDB.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: ProvidersDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProvidersDB provider = db.ProvidersDB.Find(id);
            db.ProvidersDB.Remove(provider);
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
