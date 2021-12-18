using System;
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
    public class geklineupsController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();

        // GET: geklineups
        public ActionResult Index()
        {
            var geklineup = db.geklineup.Include(g => g.eventlog);
            return View(geklineup.ToList());
        }

        // GET: geklineups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            geklineup geklineup = db.geklineup.Find(id);
            if (geklineup == null)
            {
                return HttpNotFound();
            }
            return View(geklineup);
        }

        // GET: geklineups/Create
        public ActionResult Create()
        {
            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr");
            return View();
        }

        // POST: geklineups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,groupid,eventid")] geklineup geklineup)
        {
            if (ModelState.IsValid)
            {
                db.geklineup.Add(geklineup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr", geklineup.eventid);
            return View(geklineup);
        }

        // GET: geklineups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            geklineup geklineup = db.geklineup.Find(id);
            if (geklineup == null)
            {
                return HttpNotFound();
            }
            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr", geklineup.eventid);
            return View(geklineup);
        }

        // POST: geklineups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,groupid,eventid")] geklineup geklineup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geklineup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr", geklineup.eventid);
            return View(geklineup);
        }

        // GET: geklineups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            geklineup geklineup = db.geklineup.Find(id);
            if (geklineup == null)
            {
                return HttpNotFound();
            }
            return View(geklineup);
        }

        // POST: geklineups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            geklineup geklineup = db.geklineup.Find(id);
            db.geklineup.Remove(geklineup);
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
