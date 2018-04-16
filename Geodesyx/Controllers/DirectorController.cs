using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geodesyx.Service;

namespace Geodesyx.Controllers
{
    public class DirectorController : Controller
    {
        public bool Auth()
        {
            try
            {
                string user_type = Request.Cookies["user_type"].Value;
                return user_type == "2";
            }
            catch
            {
                return false;
            }
        }

        public ActionResult Index()
        {
            if (!Auth())
                return Redirect("/Home/Index");
            //бригады
            var service_brigades = new SBrigade.BrigadeClient();
            ViewBag.BrigadeList = service_brigades.SelectBrigades();

            //законченные задачи
            var service_brigade_end_tasks = new SBrigadeEndedTasks();
            ViewBag.EndedTasksList = service_brigade_end_tasks.SelectAll();



            return View();
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
