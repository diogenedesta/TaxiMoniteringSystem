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
    public class TariffController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: Tariff
        public ActionResult Index()
        {
            return View(db.tbl_Tariff.ToList());
        }

        // GET: Tariff/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Tariff tbl_Tariff = db.tbl_Tariff.Find(id);
            if (tbl_Tariff == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tariff);
        }

        // GET: Tariff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tariff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tariff_Id,Tariff_Amount,Tariff_Update_Date")] tbl_Tariff tbl_Tariff)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Tariff.Add(tbl_Tariff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Tariff);
        }

        // GET: Tariff/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Tariff tbl_Tariff = db.tbl_Tariff.Find(id);
            if (tbl_Tariff == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tariff);
        }

        // POST: Tariff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tariff_Id,Tariff_Amount,Tariff_Update_Date")] tbl_Tariff tbl_Tariff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Tariff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Tariff);
        }

        // GET: Tariff/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Tariff tbl_Tariff = db.tbl_Tariff.Find(id);
            if (tbl_Tariff == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tariff);
        }

        // POST: Tariff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Tariff tbl_Tariff = db.tbl_Tariff.Find(id);
            db.tbl_Tariff.Remove(tbl_Tariff);
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
