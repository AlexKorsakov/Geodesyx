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
        //Service1 DBops = new Service1();

        [Authorize]
        public ActionResult Index()
        {
            /*
            var cookie = new HttpCookie("auth")
            {
                Value = DateTime.Now.ToString("dd.MM.yyyy"),
                Expires = DateTime.Now.AddDays(1),
            };
            Response.SetCookie(cookie);
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Тут будет описание.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты.";

            return View();
        }
    }
}