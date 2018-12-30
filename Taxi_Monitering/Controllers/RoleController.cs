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
    public class RoleController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Role
        public ActionResult Index()
        {
            return View(db.tbl_Role.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Role tbl_Role = db.tbl_Role.Find(id);
            if (tbl_Role == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Role_ID,Role_Description,Role_Permission")] tbl_Role tbl_Role)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Role.Add(tbl_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Role);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Role tbl_Role = db.tbl_Role.Find(id);
            if (tbl_Role == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Role);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Role_ID,Role_Description,Role_Permission")] tbl_Role tbl_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Role);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Role tbl_Role = db.tbl_Role.Find(id);
            if (tbl_Role == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Role tbl_Role = db.tbl_Role.Find(id);
            db.tbl_Role.Remove(tbl_Role);
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
