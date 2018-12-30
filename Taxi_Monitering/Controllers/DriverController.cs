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
    public class DriverController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Driver
        public ActionResult Index()
        {
            return View(db.tbl_Driver.ToList());
        }

        // GET: Driver/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Driver tbl_Driver = db.tbl_Driver.Find(id);
            if (tbl_Driver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Driver);
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Driver_ID,Driver_First_Name,Driver_Last_Name,Driver_lisence_No")] tbl_Driver tbl_Driver)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Driver.Add(tbl_Driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Driver);
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Driver tbl_Driver = db.tbl_Driver.Find(id);
            if (tbl_Driver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Driver);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Driver_ID,Driver_First_Name,Driver_Last_Name,Driver_lisence_No")] tbl_Driver tbl_Driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Driver);
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Driver tbl_Driver = db.tbl_Driver.Find(id);
            if (tbl_Driver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Driver);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Driver tbl_Driver = db.tbl_Driver.Find(id);
            db.tbl_Driver.Remove(tbl_Driver);
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
