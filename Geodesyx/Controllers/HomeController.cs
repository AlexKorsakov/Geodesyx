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
        public ActionResult Index()
        {
            string user_type = "";
            try
            {
                user_type = Request.Cookies["user_type"].Value;
            }
            catch
            {

            }
            if (user_type != "")
                switch (user_type)
                {
                    case "1":
                        return RedirectToAction("Index", "Secretary");
                    case "3":
                        return RedirectToAction("Index", "BrigadeLead");
                    case "2":
                        return RedirectToAction("Index", "Director");
                }
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

        public ActionResult Login(FormCollection form)
        {
            string login = form["email"];
            string password = form["password"];

            var auth = new Authentication();
            var user = auth.GetUser(login, password);
            var role = auth.GetRole(user);
            try
            {
                if (role.id > -1 && user.id > -1)
                {
                    HttpCookie user_typecookie = new HttpCookie("user_type");
                    user_typecookie.Value = role.id.ToString();
                    user_typecookie.Expires = DateTime.Now.AddHours(1);
                    Response.SetCookie(user_typecookie);

                    HttpCookie usercookie = new HttpCookie("user");
                    usercookie.Value = user.id.ToString();
                    usercookie.Expires = DateTime.Now.AddHours(1);
                    Response.SetCookie(usercookie);
                }


                switch (role.id.ToString())
                {
                    case "1":
                        return Redirect("/Secretary/Index");
                    case "3":
                        return Redirect("/BrigadeLead/Index");
                    case "2":
                        return Redirect("/Director/Index");
                }
                return Redirect("/Home/Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }


        public ActionResult Logout()
        {
            HttpCookie user_typecookie = new HttpCookie("user_type");
            user_typecookie.Value = "";
            user_typecookie.Expires = DateTime.Now.AddHours(-1);
            Response.SetCookie(user_typecookie);

            HttpCookie usercookie = new HttpCookie("user");
            usercookie.Value = "";
            usercookie.Expires = DateTime.Now.AddHours(-1);
            Response.SetCookie(usercookie);

            return Redirect("/Home/Index");
        }
    }
}