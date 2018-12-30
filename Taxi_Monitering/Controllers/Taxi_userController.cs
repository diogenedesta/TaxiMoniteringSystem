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
    public class Taxi_userController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Taxi_user
        public ActionResult Index()
        {
            var tbl_Taxi_user = db.tbl_Taxi_user.Include(t => t.tbl_Taxi);
            return View(tbl_Taxi_user.ToList());
        }

        // GET: Taxi_user/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi_user tbl_Taxi_user = db.tbl_Taxi_user.Find(id);
            if (tbl_Taxi_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Taxi_user);
        }

        // GET: Taxi_user/Create
        public ActionResult Create()
        {
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code");
            return View();
        }

        // POST: Taxi_user/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Commnet,Taxi_ID")] tbl_Taxi_user tbl_Taxi_user)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Taxi_user.Add(tbl_Taxi_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code", tbl_Taxi_user.Taxi_ID);
            return View(tbl_Taxi_user);
        }

        // GET: Taxi_user/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi_user tbl_Taxi_user = db.tbl_Taxi_user.Find(id);
            if (tbl_Taxi_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code", tbl_Taxi_user.Taxi_ID);
            return View(tbl_Taxi_user);
        }

        // POST: Taxi_user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Commnet,Taxi_ID")] tbl_Taxi_user tbl_Taxi_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Taxi_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Taxi_ID = new SelectList(db.tbl_Taxi, "Taxi_ID", "Taxi_Code", tbl_Taxi_user.Taxi_ID);
            return View(tbl_Taxi_user);
        }

        // GET: Taxi_user/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Taxi_user tbl_Taxi_user = db.tbl_Taxi_user.Find(id);
            if (tbl_Taxi_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Taxi_user);
        }

        // POST: Taxi_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Taxi_user tbl_Taxi_user = db.tbl_Taxi_user.Find(id);
            db.tbl_Taxi_user.Remove(tbl_Taxi_user);
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
