﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TermProjectFacultyC;

namespace TermProjectFacultyC.Controllers
{
    public class purchaselistsController : Controller
    {
        private facultyEntities1 db = new facultyEntities1();

        // GET: purchaselists
        public ActionResult Index()
        {
            return View(db.purchaselist.ToList());
        }

        // GET: purchaselists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchaselist purchaselist = db.purchaselist.Find(id);
            if (purchaselist == null)
            {
                return HttpNotFound();
            }
            return View(purchaselist);
        }

        // GET: purchaselists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: purchaselists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,purchasename,purchasedescription,sender,quantity,price1pc,overallsum,ifapproved")] purchaselist purchaselist)
        {
            if (ModelState.IsValid)
            {
                db.purchaselist.Add(purchaselist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaselist);
        }

        // GET: purchaselists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchaselist purchaselist = db.purchaselist.Find(id);
            if (purchaselist == null)
            {
                return HttpNotFound();
            }
            return View(purchaselist);
        }

        // POST: purchaselists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,purchasename,purchasedescription,sender,quantity,price1pc,overallsum,ifapproved")] purchaselist purchaselist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaselist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaselist);
        }

        // GET: purchaselists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchaselist purchaselist = db.purchaselist.Find(id);
            if (purchaselist == null)
            {
                return HttpNotFound();
            }
            return View(purchaselist);
        }

        // POST: purchaselists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            purchaselist purchaselist = db.purchaselist.Find(id);
            db.purchaselist.Remove(purchaselist);
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
