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
    public class CompanyDBController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        // GET: CompanyDB
        public ActionResult Index()
        {
            ViewBag.Admin = User.IsInRole("admin");
            ViewBag.User = User.IsInRole("user");

            return View(db.CompanyDB.ToList());
        }

        // GET: CompanyDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDB company = db.CompanyDB.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: CompanyDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyDB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address,Specialization")] CompanyDB company)
        {
            if (ModelState.IsValid)
            {
                company.ID = db.CompanyDB.ToList().Last().ID + 1;
                db.CompanyDB.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: CompanyDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDB company = db.CompanyDB.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: CompanyDB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Specialization")] CompanyDB company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: CompanyDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDB company = db.CompanyDB.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: CompanyDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyDB company = db.CompanyDB.Find(id);
            db.CompanyDB.Remove(company);
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
