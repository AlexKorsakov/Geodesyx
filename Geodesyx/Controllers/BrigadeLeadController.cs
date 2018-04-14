using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geodesyx.Controllers
{
    public class BrigadeLeadController : Controller
    {
        // GET: BrigadeLead
        public ActionResult Index()
        {
            return View();
        }

        // GET: BrigadeLead/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrigadeLead/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrigadeLead/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BrigadeLead/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrigadeLead/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BrigadeLead/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrigadeLead/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
