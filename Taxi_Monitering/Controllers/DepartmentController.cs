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
    public class DepartmentController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.tbl_Department.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Department_ID,Department_Name")] tbl_Department tbl_Department)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Department.Add(tbl_Department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Department_ID,Department_Name")] tbl_Department tbl_Department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            db.tbl_Department.Remove(tbl_Department);
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
