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
    public class geksController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();

        // GET: geks
        public ActionResult Index()
        {
            return View(db.gek.ToList());
        }

        // GET: geks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gek gek = db.gek.Find(id);
            if (gek == null)
            {
                return HttpNotFound();
            }
            return View(gek);
        }

        // GET: geks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: geks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,lastname,firstname,patronymic,placeofwork,position")] gek gek)
        {
            if (ModelState.IsValid)
            {
                db.gek.Add(gek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gek);
        }

        // GET: geks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gek gek = db.gek.Find(id);
            if (gek == null)
            {
                return HttpNotFound();
            }
            return View(gek);
        }

        // POST: geks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,lastname,firstname,patronymic,placeofwork,position")] gek gek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gek);
        }

        // GET: geks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gek gek = db.gek.Find(id);
            if (gek == null)
            {
                return HttpNotFound();
            }
            return View(gek);
        }

        // POST: geks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gek gek = db.gek.Find(id);
            db.gek.Remove(gek);
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
