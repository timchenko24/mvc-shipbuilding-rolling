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
    public class RollingDBController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        // GET: RollingDB
        public ActionResult Index()
        {
            ViewBag.Admin = User.IsInRole("admin");
            ViewBag.User = User.IsInRole("user");

            var rollingDB = db.RollingDB.Include(r => r.ProducerDB).Include(r => r.ProvidersDB);
            return View(rollingDB.ToList());
        }

        // GET: RollingDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollingDB rolling = db.RollingDB.Find(id);
            if (rolling == null)
            {
                return HttpNotFound();
            }
            return View(rolling);
        }

        // GET: RollingDB/Create
        public ActionResult Create()
        {
            ViewBag.ProducerID = new SelectList(db.ProducerDB, "ID", "Name");
            ViewBag.ProviderID = new SelectList(db.ProvidersDB, "ID", "Name");
            return View();
        }

        // POST: RollingDB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProviderID,ProducerID,Name,Document,Form,Processing")] RollingDB rolling)
        {
            if (ModelState.IsValid)
            {
                rolling.ID = db.RollingDB.ToList().Last().ID + 1;
                db.RollingDB.Add(rolling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProducerID = new SelectList(db.ProducerDB, "ID", "Name", rolling.ProducerID);
            ViewBag.ProviderID = new SelectList(db.ProvidersDB, "ID", "Name", rolling.ProviderID);
            return View(rolling);
        }

        // GET: RollingDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollingDB rolling = db.RollingDB.Find(id);
            if (rolling == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProducerID = new SelectList(db.ProducerDB, "ID", "Name", rolling.ProducerID);
            ViewBag.ProviderID = new SelectList(db.ProvidersDB, "ID", "Name", rolling.ProviderID);
            return View(rolling);
        }

        // POST: RollingDB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProviderID,ProducerID,Name,Document,Form,Processing")] RollingDB rollingDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollingDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProducerID = new SelectList(db.ProducerDB, "ID", "Name", rollingDB.ProducerID);
            ViewBag.ProviderID = new SelectList(db.ProvidersDB, "ID", "Name", rollingDB.ProviderID);
            return View(rollingDB);
        }

        // GET: RollingDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollingDB rolling = db.RollingDB.Find(id);
            if (rolling == null)
            {
                return HttpNotFound();
            }
            return View(rolling);
        }

        // POST: RollingDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RollingDB rolling = db.RollingDB.Find(id);
            db.RollingDB.Remove(rolling);
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
