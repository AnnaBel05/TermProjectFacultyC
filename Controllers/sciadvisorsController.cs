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
    public class sciadvisorsController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();

        // GET: sciadvisors
        public ActionResult Index()
        {
            return View(db.sciadvisor.ToList());
        }

        // GET: sciadvisors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sciadvisor sciadvisor = db.sciadvisor.Find(id);
            if (sciadvisor == null)
            {
                return HttpNotFound();
            }
            return View(sciadvisor);
        }

        // GET: sciadvisors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sciadvisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,professor,hoursGW,hoursperGW,takenGWquantity,freeGWquantity")] sciadvisor sciadvisor)
        {
            if (ModelState.IsValid)
            {
                db.sciadvisor.Add(sciadvisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sciadvisor);
        }

        // GET: sciadvisors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sciadvisor sciadvisor = db.sciadvisor.Find(id);
            if (sciadvisor == null)
            {
                return HttpNotFound();
            }
            return View(sciadvisor);
        }

        // POST: sciadvisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,professor,hoursGW,hoursperGW,takenGWquantity,freeGWquantity")] sciadvisor sciadvisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sciadvisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sciadvisor);
        }

        // GET: sciadvisors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sciadvisor sciadvisor = db.sciadvisor.Find(id);
            if (sciadvisor == null)
            {
                return HttpNotFound();
            }
            return View(sciadvisor);
        }

        // POST: sciadvisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sciadvisor sciadvisor = db.sciadvisor.Find(id);
            db.sciadvisor.Remove(sciadvisor);
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
