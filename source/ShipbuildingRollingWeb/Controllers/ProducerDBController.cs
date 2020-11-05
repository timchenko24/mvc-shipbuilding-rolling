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
    public class ProducerDBController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        // GET: ProducerDB
        public ActionResult Index()
        {
            ViewBag.Admin = User.IsInRole("admin");
            ViewBag.User = User.IsInRole("user");

            return View(db.ProducerDB.ToList());
        }

        // GET: ProducerDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDB producer = db.ProducerDB.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // GET: ProducerDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducerDB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address")] ProducerDB producer)
        {
            if (ModelState.IsValid)
            {
                producer.ID = db.ProducerDB.ToList().Last().ID + 1;
                db.ProducerDB.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        // GET: ProducerDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDB producer = db.ProducerDB.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: ProducerDB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address")] ProducerDB producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        // GET: ProducerDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDB producer = db.ProducerDB.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: ProducerDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducerDB producer = db.ProducerDB.Find(id);
            db.ProducerDB.Remove(producer);
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
