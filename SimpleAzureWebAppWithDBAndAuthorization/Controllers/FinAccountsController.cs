using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleAzureWebAppWithDBAndAuthorization.Models;

namespace SimpleAzureWebAppWithDBAndAuthorization.Controllers
{
    public class FinAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinAccounts
        public ActionResult Index()
        {
            return View(db.FinAccounts.ToList());
        }

        // GET: FinAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinAccount finAccount = db.FinAccounts.Find(id);
            if (finAccount == null)
            {
                return HttpNotFound();
            }
            return View(finAccount);
        }

        // GET: FinAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,InitialBalance")] FinAccount finAccount)
        {
            if (ModelState.IsValid)
            {
                db.FinAccounts.Add(finAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finAccount);
        }

        // GET: FinAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinAccount finAccount = db.FinAccounts.Find(id);
            if (finAccount == null)
            {
                return HttpNotFound();
            }
            return View(finAccount);
        }

        // POST: FinAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,InitialBalance")] FinAccount finAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finAccount);
        }

        // GET: FinAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinAccount finAccount = db.FinAccounts.Find(id);
            if (finAccount == null)
            {
                return HttpNotFound();
            }
            return View(finAccount);
        }

        // POST: FinAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinAccount finAccount = db.FinAccounts.Find(id);
            db.FinAccounts.Remove(finAccount);
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
