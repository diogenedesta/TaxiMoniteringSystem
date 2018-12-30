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
    public class System_AccountController : Controller
    {
        private AACPTMCSEntities db = new AACPTMCSEntities();

        // GET: System_Account
        public ActionResult Index()
        {
            var tbl_System_Account = db.tbl_System_Account.Include(t => t.tbl_Role);
            return View(tbl_System_Account.ToList());
        }

        // GET: System_Account/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_System_Account tbl_System_Account = db.tbl_System_Account.Find(id);
            if (tbl_System_Account == null)
            {
                return HttpNotFound();
            }
            return View(tbl_System_Account);
        }

        // GET: System_Account/Create
        public ActionResult Create()
        {
            ViewBag.Role_ID = new SelectList(db.tbl_Role, "Role_ID", "Role_Description");
            return View();
        }

        // POST: System_Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Acc_ID,Acc_User_Name,ACC_Pasword,Role_ID")] tbl_System_Account tbl_System_Account)
        {
            if (ModelState.IsValid)
            {
                db.tbl_System_Account.Add(tbl_System_Account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_ID = new SelectList(db.tbl_Role, "Role_ID", "Role_Description", tbl_System_Account.Role_ID);
            return View(tbl_System_Account);
        }

        // GET: System_Account/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_System_Account tbl_System_Account = db.tbl_System_Account.Find(id);
            if (tbl_System_Account == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_ID = new SelectList(db.tbl_Role, "Role_ID", "Role_Description", tbl_System_Account.Role_ID);
            return View(tbl_System_Account);
        }

        // POST: System_Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Acc_ID,Acc_User_Name,ACC_Pasword,Role_ID")] tbl_System_Account tbl_System_Account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_System_Account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_ID = new SelectList(db.tbl_Role, "Role_ID", "Role_Description", tbl_System_Account.Role_ID);
            return View(tbl_System_Account);
        }

        // GET: System_Account/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_System_Account tbl_System_Account = db.tbl_System_Account.Find(id);
            if (tbl_System_Account == null)
            {
                return HttpNotFound();
            }
            return View(tbl_System_Account);
        }

        // POST: System_Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_System_Account tbl_System_Account = db.tbl_System_Account.Find(id);
            db.tbl_System_Account.Remove(tbl_System_Account);
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
