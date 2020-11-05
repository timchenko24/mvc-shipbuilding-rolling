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
    public class DrawingDBController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        // GET: DrawingDB
        public ActionResult Index()
        {
            ViewBag.Admin = User.IsInRole("admin");
            ViewBag.User = User.IsInRole("user");

            var drawingDB = db.DrawingDB.Include(d => d.BodyFragmentDB).Include(d => d.CompanyDB);
            return View(drawingDB.ToList());
        }

        // GET: DrawingDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingDB drawing = db.DrawingDB.Find(id);
            if (drawing == null)
            {
                return HttpNotFound();
            }
            return View(drawing);
        }

        // GET: DrawingDB/Create
        public ActionResult Create()
        {
            ViewBag.BodyFragmentID = new SelectList(db.BodyFragmentDB, "ID", "Name");
            ViewBag.CompanyID = new SelectList(db.CompanyDB, "ID", "Name");
            return View();
        }

        // POST: DrawingDB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BodyFragmentID,CompanyID,Data,Format")] DrawingDB drawing)
        {
            if (ModelState.IsValid)
            {
                drawing.ID = db.DrawingDB.ToList().Last().ID + 1;
                db.DrawingDB.Add(drawing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BodyFragmentID = new SelectList(db.BodyFragmentDB, "ID", "Name", drawing.BodyFragmentID);
            ViewBag.CompanyID = new SelectList(db.CompanyDB, "ID", "Name", drawing.CompanyID);
            return View(drawing);
        }

        // GET: DrawingDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingDB drawing = db.DrawingDB.Find(id);
            if (drawing == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyFragmentID = new SelectList(db.BodyFragmentDB, "ID", "Name", drawing.BodyFragmentID);
            ViewBag.CompanyID = new SelectList(db.CompanyDB, "ID", "Name", drawing.CompanyID);
            return View(drawing);
        }

        // POST: DrawingDB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BodyFragmentID,CompanyID,Data,Format")] DrawingDB drawingDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drawingDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BodyFragmentID = new SelectList(db.BodyFragmentDB, "ID", "Name", drawingDB.BodyFragmentID);
            ViewBag.CompanyID = new SelectList(db.CompanyDB, "ID", "Name", drawingDB.CompanyID);
            return View(drawingDB);
        }

        // GET: DrawingDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingDB drawing = db.DrawingDB.Find(id);
            if (drawing == null)
            {
                return HttpNotFound();
            }
            return View(drawing);
        }

        // POST: DrawingDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrawingDB drawing = db.DrawingDB.Find(id);
            db.DrawingDB.Remove(drawing);
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
