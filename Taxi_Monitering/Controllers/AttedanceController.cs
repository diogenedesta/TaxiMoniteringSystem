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
    public class AttedanceController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Attedance
        public ActionResult Index()
        {
            var tbl_Attedance = db.tbl_Attedance.Include(t => t.tbl_Employee).Include(t => t.tbl_Taxi);
            return View(tbl_Attedance.ToList());
        }

        // GET: Attedance/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Attedance tbl_Attedance = db.tbl_Attedance.Find(id);
            if (tbl_Attedance == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Attedance);
        }

        // GET: Attedance/Create
        public ActionResult Create()
        {
            ViewBag.Emp_Id = new SelectList(db.tbl_Employee, "Emp_Id", "Emp_First_Name");
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code");
            return View();
        }

        // POST: Attedance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Att_Id,Att_Value,Att_tkn_Time,Taxi_ID,Emp_Id")] tbl_Attedance tbl_Attedance)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Attedance.Add(tbl_Attedance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Emp_Id = new SelectList(db.tbl_Employee, "Emp_Id", "Emp_First_Name", tbl_Attedance.Emp_Id);
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code", tbl_Attedance.Taxi_ID);
            return View(tbl_Attedance);
        }

        // GET: Attedance/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Attedance tbl_Attedance = db.tbl_Attedance.Find(id);
            if (tbl_Attedance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_Id = new SelectList(db.tbl_Employee, "Emp_Id", "Emp_First_Name", tbl_Attedance.Emp_Id);
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code", tbl_Attedance.Taxi_ID);
            return View(tbl_Attedance);
        }

        // POST: Attedance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Att_Id,Att_Value,Att_tkn_Time,Taxi_ID,Emp_Id")] tbl_Attedance tbl_Attedance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Attedance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_Id = new SelectList(db.tbl_Employee, "Emp_Id", "Emp_First_Name", tbl_Attedance.Emp_Id);
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code", tbl_Attedance.Taxi_ID);
            return View(tbl_Attedance);
        }

        // GET: Attedance/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Attedance tbl_Attedance = db.tbl_Attedance.Find(id);
            if (tbl_Attedance == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Attedance);
        }

        // POST: Attedance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Attedance tbl_Attedance = db.tbl_Attedance.Find(id);
            db.tbl_Attedance.Remove(tbl_Attedance);
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
