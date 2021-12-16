using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectFacultyC.DAO;

namespace TermProjectFacultyC.Controllers
{
    public class GekController : Controller
    {
        GekDAO gekDAO = new GekDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(gekDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(gekDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] gek gek)
        {
            try
            {
                // TODO: Add insert logic here

                if (gekDAO.AddRecord(gek))
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
        public ActionResult Edit(int id, gek gek)
        {
            try
            {
                // TODO: Add update logic here

                if (gekDAO.UpdateRecord(id, gek))
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
        public ActionResult Delete(int id, gek gek)
        {
            try
            {
                // TODO: Add delete logic here
                if (gekDAO.DeleteRecord(id, gek))
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