using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;
using Geodesyx.Service;

namespace Geodesyx.Controllers
{
    public class SecretaryController : Controller
    {


        // GET: Request
        public ActionResult Index()
        {
            var service_request = new SRequest();
            ViewBag.RequestList = service_request.SelectNewRequests();
            var service_address = new SAddress();
            ViewBag.AddressList = service_address.SelectAddresses();
            var service_sevices = new SService();
            ViewBag.ServiceList = service_sevices.SelectServices();
            var service_tasks = new STask();
            ViewBag.TaskList = service_tasks.SelectNewTasks();
            var service_brigades = new SBrigade();
            ViewBag.BrigadeList = service_brigades.SelectBrigades();

            return View();
        }

        [HttpPost]
        public ActionResult AddRequest(FormCollection form)
        {
            ViewBag.ErrorMessage = "";
            var service_request = new SRequest();
            var new_request = new Models.DTO.Request();
            new_request.name = form["name"];
            new_request.description = form["description"];
            int id = service_request.Insert(new_request);

            SRequestStatusChange service_request_st_change = new SRequestStatusChange();
            var request_st_change = new Models.DTO.RequestStatusChange();
            request_st_change.old_status = null;
            request_st_change.new_status = 1;
            request_st_change.request_id = id;
            service_request_st_change.Insert(request_st_change);

            if (request_st_change.id > -1)
                return Redirect(Request.UrlReferrer.ToString());
            else
            {
                ViewBag.ErrorMessage = "Произошла ошибка при записи";
                return Index();
            }
        }

        [HttpPost]
        public ActionResult AddTask(FormCollection form)
        {
            int id_adrc = -1;
            if (form["address-new"] == "")
                Int32.TryParse(form["address"], out id_adrc);
            else
            {
                var service_address = new SAddress();
                var new_address = new Models.DTO.Address();
                string s = form["X"];
                float.TryParse(form["X"].Replace(".", ","), out new_address.X);
                float.TryParse(form["Y"].Replace(".", ","), out new_address.Y);
                new_address.address_name = form["address-new"];
                id_adrc = service_address.Insert(new_address);
            }

            var service_task = new STask();
            var new_task = new Models.DTO.Task();
            new_task.task_note = form["note"];
            new_task.address_id = id_adrc;
            Int32.TryParse(form["service_list"], out new_task.service_id);


            STaskStatusChange service_task_st_change = new STaskStatusChange();
            var task_st_change = new Models.DTO.TaskStatusChange();
            task_st_change.old_status = null;
            task_st_change.new_status = 1;
            task_st_change.task_id = service_task.Insert(new_task);
            int res = service_task_st_change.Insert(task_st_change);

            if (res > -1)
                return Redirect(Request.UrlReferrer.ToString());
            else
            {
                ViewBag.ErrorMessage = "Произошла ошибка при записи";
                return Index();
            }
        }
    }
}