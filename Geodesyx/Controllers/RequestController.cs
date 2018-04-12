using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geodesyx.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            Geodesyx.Request request = new Geodesyx.Request();
            ViewBag.RequestList = request.SelectAll();
            return View();
        }
    }
}