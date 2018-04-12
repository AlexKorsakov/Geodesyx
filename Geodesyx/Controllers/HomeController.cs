using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geodesyx.Models;


namespace Geodesyx.Controllers
{
    public class HomeController : Controller
    {
        Service1 DBops = new Service1();
        

        public ActionResult Index()
        {
            //ViewBag.data = DBops.DoWork();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Тут будет описание.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}