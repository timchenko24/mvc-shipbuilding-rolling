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
    public class BodyFragmentDBController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        // GET: BodyFragmentDB
        public ActionResult Index()
        {
            ViewBag.Admin = User.IsInRole("admin");
            ViewBag.User = User.IsInRole("user");

            var bodyFragmentDB = db.BodyFragmentDB.Include(b => b.RollingDB);
            return View(bodyFragmentDB.ToList());
        }

        // GET: BodyFragmentDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyFragmentDB bodyFragmentDB = db.BodyFragmentDB.Find(id);
            if (bodyFragmentDB == null)
            {
                return HttpNotFound();
            }
            return View(bodyFragmentDB);
        }

        // GET: BodyFragmentDB/Create
        public ActionResult Create()
        {
            ViewBag.RollingID = new SelectList(db.RollingDB, "ID", "Name");
            return View();
        }

        // POST: BodyFragmentDB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollingID,Name,Designation")] BodyFragmentDB bodyFragment)
        {
            if (ModelState.IsValid)
            {
                bodyFragment.ID = db.BodyFragmentDB.ToList().Last().ID + 1;
                db.BodyFragmentDB.Add(bodyFragment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RollingID = new SelectList(db.RollingDB, "ID", "Name", bodyFragment.RollingID);
            return View(bodyFragment);
        }

        // GET: BodyFragmentDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyFragmentDB bodyFragment = db.BodyFragmentDB.Find(id);
            if (bodyFragment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RollingID = new SelectList(db.RollingDB, "ID", "Name", bodyFragment.RollingID);
            return View(bodyFragment);
        }

        // POST: BodyFragmentDB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RollingID,Name,Designation")] BodyFragmentDB bodyFragment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyFragment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RollingID = new SelectList(db.RollingDB, "ID", "Name", bodyFragment.RollingID);
            return View(bodyFragment);
        }

        // GET: BodyFragmentDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyFragmentDB bodyFragment = db.BodyFragmentDB.Find(id);
            if (bodyFragment == null)
            {
                return HttpNotFound();
            }
            return View(bodyFragment);
        }

        // POST: BodyFragmentDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodyFragmentDB bodyFragment = db.BodyFragmentDB.Find(id);
            db.BodyFragmentDB.Remove(bodyFragment);
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
