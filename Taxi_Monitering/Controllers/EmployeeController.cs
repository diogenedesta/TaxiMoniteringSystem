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
    public class EmployeeController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var tbl_Employee = db.tbl_Employee.Include(t => t.tbl_Department).Include(t => t.tbl_System_Account);
            return View(tbl_Employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.Department_ID = new SelectList(db.tbl_Department, "Department_ID", "Department_Name");
            ViewBag.Acc_ID = new SelectList(db.tbl_System_Account, "Acc_ID", "Acc_User_Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_Id,Emp_First_Name,Emp_Last_name,Emp_Act_date,Emp_Postion,Department_ID,Acc_ID,Emp_Gender")] tbl_Employee tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Employee.Add(tbl_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department_ID = new SelectList(db.tbl_Department, "Department_ID", "Department_Name", tbl_Employee.Department_ID);
            ViewBag.Acc_ID = new SelectList(db.tbl_System_Account, "Acc_ID", "Acc_User_Name", tbl_Employee.Acc_ID);
            return View(tbl_Employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department_ID = new SelectList(db.tbl_Department, "Department_ID", "Department_Name", tbl_Employee.Department_ID);
            ViewBag.Acc_ID = new SelectList(db.tbl_System_Account, "Acc_ID", "Acc_User_Name", tbl_Employee.Acc_ID);
            return View(tbl_Employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_Id,Emp_First_Name,Emp_Last_name,Emp_Act_date,Emp_Postion,Department_ID,Acc_ID,Emp_Gender")] tbl_Employee tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department_ID = new SelectList(db.tbl_Department, "Department_ID", "Department_Name", tbl_Employee.Department_ID);
            ViewBag.Acc_ID = new SelectList(db.tbl_System_Account, "Acc_ID", "Acc_User_Name", tbl_Employee.Acc_ID);
            return View(tbl_Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            db.tbl_Employee.Remove(tbl_Employee);
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
