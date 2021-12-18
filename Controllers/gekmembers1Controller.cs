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
    public class gekmembers1Controller : Controller
    {
        private facultyEntities1 db = new facultyEntities1();

        // GET: gekmembers1
        public ActionResult Index()
        {
            var gekmembers = db.gekmembers.Include(g => g.gek).Include(g => g.gek1).Include(g => g.gek2).Include(g => g.gek3).Include(g => g.gek4).Include(g => g.sciadvisor);
            return View(gekmembers.ToList());
        }

        // GET: gekmembers1/Details/5
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

        // GET: gekmembers1/Create
        public ActionResult Create()
        {
            ViewBag.member2 = new SelectList(db.gek, "id", "lastname");
            ViewBag.member3 = new SelectList(db.gek, "id", "lastname");
            ViewBag.member4 = new SelectList(db.gek, "id", "lastname");
            ViewBag.president = new SelectList(db.gek, "id", "lastname");
            ViewBag.secretary = new SelectList(db.gek, "id", "lastname");
            ViewBag.membersciadv = new SelectList(db.sciadvisor, "id", "id");
            return View();
        }

        // POST: gekmembers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,secretary,president,membersciadv,member2,member3,member4")] gekmembers gekmembers)
        {
            if (ModelState.IsValid)
            {
                db.gekmembers.Add(gekmembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.member2 = new SelectList(db.gek, "id", "lastname", gekmembers.member2);
            ViewBag.member3 = new SelectList(db.gek, "id", "lastname", gekmembers.member3);
            ViewBag.member4 = new SelectList(db.gek, "id", "lastname", gekmembers.member4);
            ViewBag.president = new SelectList(db.gek, "id", "lastname", gekmembers.president);
            ViewBag.secretary = new SelectList(db.gek, "id", "lastname", gekmembers.secretary);
            ViewBag.membersciadv = new SelectList(db.sciadvisor, "id", "id", gekmembers.membersciadv);
            return View(gekmembers);
        }

        // GET: gekmembers1/Edit/5
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
            ViewBag.member2 = new SelectList(db.gek, "id", "lastname", gekmembers.member2);
            ViewBag.member3 = new SelectList(db.gek, "id", "lastname", gekmembers.member3);
            ViewBag.member4 = new SelectList(db.gek, "id", "lastname", gekmembers.member4);
            ViewBag.president = new SelectList(db.gek, "id", "lastname", gekmembers.president);
            ViewBag.secretary = new SelectList(db.gek, "id", "lastname", gekmembers.secretary);
            ViewBag.membersciadv = new SelectList(db.sciadvisor, "id", "id", gekmembers.membersciadv);
            return View(gekmembers);
        }

        // POST: gekmembers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,secretary,president,membersciadv,member2,member3,member4")] gekmembers gekmembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gekmembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.member2 = new SelectList(db.gek, "id", "lastname", gekmembers.member2);
            ViewBag.member3 = new SelectList(db.gek, "id", "lastname", gekmembers.member3);
            ViewBag.member4 = new SelectList(db.gek, "id", "lastname", gekmembers.member4);
            ViewBag.president = new SelectList(db.gek, "id", "lastname", gekmembers.president);
            ViewBag.secretary = new SelectList(db.gek, "id", "lastname", gekmembers.secretary);
            ViewBag.membersciadv = new SelectList(db.sciadvisor, "id", "id", gekmembers.membersciadv);
            return View(gekmembers);
        }

        // GET: gekmembers1/Delete/5
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

        // POST: gekmembers1/Delete/5
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
