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
    public class tbl_Taxi_OwnerController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: tbl_Taxi_Owner
        public ActionResult Index()
        {
            var tbl_Taxi_Owner = db.tbl_Taxi_Owner.Include(t => t.tbl_Driver);
            return View(tbl_Taxi_Owner.ToList());
        }

        // GET: tbl_Taxi_Owner/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi_Owner tbl_Taxi_Owner = db.tbl_Taxi_Owner.Find(id);
            if (tbl_Taxi_Owner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Taxi_Owner);
        }

        // GET: tbl_Taxi_Owner/Create
        public ActionResult Create()
        {
            ViewBag.Driver_ID = new SelectList(db.tbl_Driver, "Driver_ID", "Driver_First_Name");
            return View();
        }

        // POST: tbl_Taxi_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Owr_Id,Owr_First_Name,Owr_Last_name,Owr_Reg_city,Owr_Reg_date,Owr_Gender,Owr_Subcity,Owr_Wereda,Owr_House_NO,Owr_PIN,Driver_ID")] tbl_Taxi_Owner tbl_Taxi_Owner)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Taxi_Owner.Add(tbl_Taxi_Owner);
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }

            ViewBag.Driver_ID = new SelectList(db.tbl_Driver, "Driver_ID", "Driver_First_Name", tbl_Taxi_Owner.Driver_ID);
            return View(tbl_Taxi_Owner);
        }

        // GET: tbl_Taxi_Owner/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi_Owner tbl_Taxi_Owner = db.tbl_Taxi_Owner.Find(id);
            if (tbl_Taxi_Owner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Driver_ID = new SelectList(db.tbl_Driver, "Driver_ID", "Driver_First_Name", tbl_Taxi_Owner.Driver_ID);
            return View(tbl_Taxi_Owner);
        }

        // POST: tbl_Taxi_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Owr_Id,Owr_First_Name,Owr_Last_name,Owr_Reg_city,Owr_Reg_date,Owr_Gender,Owr_Subcity,Owr_Wereda,Owr_House_NO,Owr_PIN,Driver_ID")] tbl_Taxi_Owner tbl_Taxi_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Taxi_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Driver_ID = new SelectList(db.tbl_Driver, "Driver_ID", "Driver_First_Name", tbl_Taxi_Owner.Driver_ID);
            return View(tbl_Taxi_Owner);
        }

        // GET: tbl_Taxi_Owner/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi_Owner tbl_Taxi_Owner = db.tbl_Taxi_Owner.Find(id);
            if (tbl_Taxi_Owner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Taxi_Owner);
        }

        // POST: tbl_Taxi_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Taxi_Owner tbl_Taxi_Owner = db.tbl_Taxi_Owner.Find(id);
            db.tbl_Taxi_Owner.Remove(tbl_Taxi_Owner);
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
