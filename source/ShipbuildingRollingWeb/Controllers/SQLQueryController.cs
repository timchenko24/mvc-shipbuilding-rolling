using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShipbuildingRollingWeb.Models.DB;

namespace ShipbuildingRollingWeb.Controllers
{
    public class SQLQueryController : Controller
    {
        private ShipbuildingRollingDBEntities db = new ShipbuildingRollingDBEntities();

        public ActionResult BodyFragmentQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BodyFragmentQuery(List<string> query)
        {
            string str = "select " + query.First() + " from BodyFragmentDB " + query.Last();
            var result = db.BodyFragmentDB.SqlQuery(str).ToList();
            return View(result);
        }

        public ActionResult CompanyQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompanyQuery(List<string> query)
        {
            string str = "select " + query.First() + " from CompanyDB " + query.Last();
            var result = db.CompanyDB.SqlQuery(str).ToList();
            return View(result);
        }

        public ActionResult DrawingQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DrawingQuery(List<string> query)
        {
            string str = "select " + query.First() + " from DrawingDB " + query.Last();
            var result = db.DrawingDB.SqlQuery(str).ToList();
            return View(result);
        }

        public ActionResult ProducerQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProducerQuery(List<string> query)
        {
            string str = "select " + query.First() + " from ProducerDB " + query.Last();
            var result = db.ProducerDB.SqlQuery(str).ToList();
            return View(result);
        }

        public ActionResult ProviderQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProviderQuery(List<string> query)
        {
            string str = "select " + query.First() + " from ProvidersDB " + query.Last();
            var result = db.ProvidersDB.SqlQuery(str).ToList();
            return View(result);
        }

        public ActionResult RollingQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RollingQuery(List<string> query)
        {
            string str = "select " + query.First() + " from RollingDB " + query.Last();
            var result = db.RollingDB.SqlQuery(str).ToList();
            return View(result);
        }
    }
}