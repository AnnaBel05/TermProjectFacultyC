using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectFacultyC.DAO;

namespace TermProjectFacultyC.Controllers
{
    public class SciAdvisorController : Controller
    {
        SciAdvisorDAO sciadvisorDAO = new SciAdvisorDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(sciadvisorDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(sciadvisorDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] sciadvisor sciadvisor)
        {
            try
            {
                // TODO: Add insert logic here

                if (sciadvisorDAO.AddRecord(sciadvisor))
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
        public ActionResult Edit(int id, sciadvisor sciadvisor)
        {
            try
            {
                // TODO: Add update logic here

                if (sciadvisorDAO.UpdateRecord(id, sciadvisor))
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
        public ActionResult Delete(int id, sciadvisor sciadvisor)
        {
            try
            {
                // TODO: Add delete logic here
                if (sciadvisorDAO.DeleteRecord(id, sciadvisor))
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