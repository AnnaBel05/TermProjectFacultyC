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
    public class gekmembersController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();

        // GET: gekmembers
        public ActionResult Index()
        {
            var gekmembers = db.gekmembers.Include(g => g.gek).Include(g => g.geklineup);
            return View(gekmembers.ToList());
        }

        // GET: gekmembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gekmembers gekmembers = db.gekmembers.Find(id);
            if (gekmembers == null)
            {
                return HttpNotFound();
            }
            return View(gekmembers);
        }

        // GET: gekmembers/Create
        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.gek, "id", "lastname");
            ViewBag.gekid = new SelectList(db.geklineup, "id", "id");
            return View();
        }

        // POST: gekmembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,memberid,gekposition,gekid")] gekmembers gekmembers)
        {
            if (ModelState.IsValid)
            {
                db.gekmembers.Add(gekmembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.gek, "id", "lastname", gekmembers.memberid);
            ViewBag.gekid = new SelectList(db.geklineup, "id", "id", gekmembers.gekid);
            return View(gekmembers);
        }

        // GET: gekmembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gekmembers gekmembers = db.gekmembers.Find(id);
            if (gekmembers == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.gek, "id", "lastname", gekmembers.memberid);
            ViewBag.gekid = new SelectList(db.geklineup, "id", "id", gekmembers.gekid);
            return View(gekmembers);
        }

        // POST: gekmembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,memberid,gekposition,gekid")] gekmembers gekmembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gekmembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.gek, "id", "lastname", gekmembers.memberid);
            ViewBag.gekid = new SelectList(db.geklineup, "id", "id", gekmembers.gekid);
            return View(gekmembers);
        }

        // GET: gekmembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gekmembers gekmembers = db.gekmembers.Find(id);
            if (gekmembers == null)
            {
                return HttpNotFound();
            }
            return View(gekmembers);
        }

        // POST: gekmembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gekmembers gekmembers = db.gekmembers.Find(id);
            db.gekmembers.Remove(gekmembers);
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
