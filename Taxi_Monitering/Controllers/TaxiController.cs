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
    public class TaxiController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Taxi
        public ActionResult Index()
        {
            var tbl_Taxi = db.tbl_Taxi.Include(t => t.tbl_Taxi_Owner).Include(t => t.tbl_Zone);
            return View(tbl_Taxi.ToList());
        }

        // GET: Taxi/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi tbl_Taxi = db.tbl_Taxi.Find(id);
            if (tbl_Taxi == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Taxi);
        }

        // GET: Taxi/Create
        public ActionResult Create()
        {
            ViewBag.Owr_Id = new SelectList(db.tbl_Taxi_Owner, "Owr_Id", "Owr_First_Name");
            ViewBag.Zone_Id = new SelectList(db.tbl_Zone, "Zone_Id", "Zone_Name");
            return View();
        }

        // POST: Taxi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Taxi_ID,Taxi_Code,Taxi_Manf_Year,Taxi_Model,Taxi_Licence_No,Zone_Id,Owr_Id,Driver_ID")] tbl_Taxi tbl_Taxi)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Taxi.Add(tbl_Taxi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Owr_Id = new SelectList(db.tbl_Taxi_Owner, "Owr_Id", "Owr_First_Name", tbl_Taxi.Owr_Id);
            ViewBag.Zone_Id = new SelectList(db.tbl_Zone, "Zone_Id", "Zone_Name", tbl_Taxi.Zone_Id);
            return View(tbl_Taxi);
        }

        // GET: Taxi/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi tbl_Taxi = db.tbl_Taxi.Find(id);
            if (tbl_Taxi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Owr_Id = new SelectList(db.tbl_Taxi_Owner, "Owr_Id", "Owr_First_Name", tbl_Taxi.Owr_Id);
            ViewBag.Zone_Id = new SelectList(db.tbl_Zone, "Zone_Id", "Zone_Name", tbl_Taxi.Zone_Id);
            return View(tbl_Taxi);
        }

        // POST: Taxi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Taxi_ID,Taxi_Code,Taxi_Manf_Year,Taxi_Model,Taxi_Licence_No,Zone_Id,Owr_Id,Driver_ID")] tbl_Taxi tbl_Taxi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Taxi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Owr_Id = new SelectList(db.tbl_Taxi_Owner, "Owr_Id", "Owr_First_Name", tbl_Taxi.Owr_Id);
            ViewBag.Zone_Id = new SelectList(db.tbl_Zone, "Zone_Id", "Zone_Name", tbl_Taxi.Zone_Id);
            return View(tbl_Taxi);
        }

        // GET: Taxi/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi tbl_Taxi = db.tbl_Taxi.Find(id);
            if (tbl_Taxi == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Taxi);
        }

        // POST: Taxi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Taxi tbl_Taxi = db.tbl_Taxi.Find(id);
            db.tbl_Taxi.Remove(tbl_Taxi);
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
