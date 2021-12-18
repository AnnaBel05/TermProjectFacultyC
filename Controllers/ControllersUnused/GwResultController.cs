using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectFacultyC.DAO;

namespace TermProjectFacultyC.Controllers
{
    public class GwResultController : Controller
    {
        GwResultDAO gwResultDAO = new GwResultDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(gwResultDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(gwResultDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] gwresult gwresult)
        {
            try
            {
                // TODO: Add insert logic here

                if (gwResultDAO.AddRecord(gwresult))
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
        public ActionResult Edit(int id, gwresult gwresult)
        {
            try
            {
                // TODO: Add update logic here

                if (gwResultDAO.UpdateRecord(id, gwresult))
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
        public ActionResult Delete(int id, gwresult gwresult)
        {
            try
            {
                // TODO: Add delete logic here
                if (gwResultDAO.DeleteRecord(id, gwresult))
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