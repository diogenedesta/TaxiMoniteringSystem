using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taxi_Monitering;

namespace Taxi_Monitering.Controllers
{
    public class ZoneController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Zone
        public ActionResult Index()
        {
            return View(db.tbl_Zone.ToList());
        }

        // GET: Zone/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Zone tbl_Zone = db.tbl_Zone.Find(id);
            if (tbl_Zone == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Zone);
        }

        // GET: Zone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zone_Id,Zone_Name,Zone_Description,Zone_Act_Date")] tbl_Zone tbl_Zone)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Zone.Add(tbl_Zone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Zone);
        }

        // GET: Zone/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Zone tbl_Zone = db.tbl_Zone.Find(id);
            if (tbl_Zone == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Zone);
        }

        // POST: Zone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zone_Id,Zone_Name,Zone_Description,Zone_Act_Date")] tbl_Zone tbl_Zone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Zone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Zone);
        }

        // GET: Zone/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Zone tbl_Zone = db.tbl_Zone.Find(id);
            if (tbl_Zone == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Zone);
        }

        // POST: Zone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Zone tbl_Zone = db.tbl_Zone.Find(id);
            db.tbl_Zone.Remove(tbl_Zone);
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
