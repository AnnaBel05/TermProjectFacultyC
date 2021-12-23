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
    [Authorize]
    public class eventlogsController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();

        // GET: eventlogs
        public ActionResult Index()
        {
            return View(db.eventlog.ToList());
        }

        // GET: eventlogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventlog eventlog = db.eventlog.Find(id);
            if (eventlog == null)
            {
                return HttpNotFound();
            }
            return View(eventlog);
        }

        [Authorize (Roles= "Техник")]
        // GET: eventlogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Техник")]
        public ActionResult Create([Bind(Include = "id,eventdate,eventplace,responsibleprofessor,eventdescr")] eventlog eventlog)
        {
            if (ModelState.IsValid)
            {
                db.eventlog.Add(eventlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventlog);
        }

        // GET: eventlogs/Edit/5
        [Authorize(Roles = "Техник")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventlog eventlog = db.eventlog.Find(id);
            if (eventlog == null)
            {
                return HttpNotFound();
            }
            return View(eventlog);
        }

        // POST: eventlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Техник")]
        public ActionResult Edit([Bind(Include = "id,eventdate,eventplace,responsibleprofessor,eventdescr")] eventlog eventlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventlog);
        }

        // GET: eventlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventlog eventlog = db.eventlog.Find(id);
            if (eventlog == null)
            {
                return HttpNotFound();
            }
            return View(eventlog);
        }

        // POST: eventlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventlog eventlog = db.eventlog.Find(id);
            db.eventlog.Remove(eventlog);
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
