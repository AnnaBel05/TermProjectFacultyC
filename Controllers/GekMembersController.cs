using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectFacultyC.DAO;

namespace TermProjectFacultyC.Controllers
{
    public class GekMembersController : Controller
    {
        GekMembersDAO gekMembersDAO = new GekMembersDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(gekMembersDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(gekMembersDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] gekmembers gekmembers)
        {
            try
            {
                // TODO: Add insert logic here

                if (gekMembersDAO.AddRecord(gekmembers))
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
        public ActionResult Edit(int id, gekmembers gekmembers)
        {
            try
            {
                // TODO: Add update logic here

                if (gekMembersDAO.UpdateRecord(id, gekmembers))
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
        public ActionResult Delete(int id, gekmembers gekmembers)
        {
            try
            {
                // TODO: Add delete logic here
                if (gekMembersDAO.DeleteRecord(id, gekmembers))
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