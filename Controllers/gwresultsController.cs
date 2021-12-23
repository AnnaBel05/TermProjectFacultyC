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
    public class gwresultsController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();

        // GET: gwresults
        public ActionResult Index()
        {
            var gwresult = db.gwresult.Include(g => g.eventlog).Include(g => g.gekmembers);
            return View(gwresult.ToList());
        }

        // GET: gwresults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gwresult gwresult = db.gwresult.Find(id);
            if (gwresult == null)
            {
                return HttpNotFound();
            }
            return View(gwresult);
        }

        // GET: gwresults/Create
        public ActionResult Create()
        {
            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr");
            ViewBag.gekid = new SelectList(db.gekmembers, "id", "gekposition");
            return View();
        }

        // POST: gwresults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,eventid,gekid,gw,mark")] gwresult gwresult)
        {
            if (ModelState.IsValid)
            {
                db.gwresult.Add(gwresult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr", gwresult.eventid);
            ViewBag.gekid = new SelectList(db.gekmembers, "id", "gekposition", gwresult.gekid);
            return View(gwresult);
        }

        // GET: gwresults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gwresult gwresult = db.gwresult.Find(id);
            if (gwresult == null)
            {
                return HttpNotFound();
            }
            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr", gwresult.eventid);
            ViewBag.gekid = new SelectList(db.gekmembers, "id", "gekposition", gwresult.gekid);
            return View(gwresult);
        }

        // POST: gwresults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,eventid,gekid,gw,mark")] gwresult gwresult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gwresult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.eventid = new SelectList(db.eventlog, "id", "eventdescr", gwresult.eventid);
            ViewBag.gekid = new SelectList(db.gekmembers, "id", "gekposition", gwresult.gekid);
            return View(gwresult);
        }

        // GET: gwresults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gwresult gwresult = db.gwresult.Find(id);
            if (gwresult == null)
            {
                return HttpNotFound();
            }
            return View(gwresult);
        }

        // POST: gwresults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gwresult gwresult = db.gwresult.Find(id);
            db.gwresult.Remove(gwresult);
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
