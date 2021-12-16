using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectFacultyC.DAO;

namespace TermProjectFacultyC.Controllers
{
    public class EventLogController : Controller
    {
        EventLogDAO eventLogDAO = new EventLogDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(eventLogDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(eventLogDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] eventlog eventlog)
        {
            try
            {
                // TODO: Add insert logic here

                if (eventLogDAO.AddRecord(eventlog))
                { return RedirectToAction("Index"); }
                else
                {
                    return View("Create");
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, eventlog eventlog)
        {
            try
            {
                // TODO: Add update logic here

                if (eventLogDAO.UpdateRecord(id, eventlog))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, eventlog eventlog)
        {
            try
            {
                // TODO: Add delete logic here
                if (eventLogDAO.DeleteRecord(id, eventlog))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}