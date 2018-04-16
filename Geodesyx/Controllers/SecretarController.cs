using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.DataAccess.Client;
using Geodesyx.Service;
using Geodesyx.Models;

namespace Geodesyx.Controllers
{

    public class SecretaryController : Controller
    {
        public bool Auth()
        {
            try
            {
                string user_type = Request.Cookies["user_type"].Value;
                return user_type == "1";
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

            OracleWcfService.OracleWcfServiceClient proxy = new OracleWcfService.OracleWcfServiceClient();

            //заявки
            var service_request = new SRequest();
            ViewBag.RequestList = service_request.SelectNewRequests();
            //статусы заявки
            var service_request_status = new SRequestStatus();
            ViewBag.RequestStatusList = service_request_status.SelectAll();
            //связь статусы-заявки
            var service_request_status_change = new SRequestStatusChange();
            var ids = new List<int>();
            foreach (var item in ViewBag.RequestList)
                ids.Add(item.id);
            ViewBag.RequestStatusChangeList = service_request_status_change.Select(ids);
            //адреса
            var service_address = new SAddress();
            ViewBag.AddressList = service_address.SelectAddresses();
            //услуги
            var service_sevices = new SService();
            ViewBag.ServiceList = service_sevices.SelectServices();
            //задачи
            var service_tasks = new STask();
            ViewBag.TaskList = service_tasks.SelectNewTasks();

            //статусы задачи
            var service_task_status = new STaskStatus();
            ViewBag.TaskStatusList = service_task_status.SelectAll();
            //связь статусы-задачи
            var service_task_status_change = new STaskStatusChange();
            ids = new List<int>();
            foreach (var item in ViewBag.TaskList)
                ids.Add(item.id);
            ViewBag.TaskStatusChangeList = service_task_status_change.Select(ids);

            //бригады
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
            var service_task = new STask();
            var service_task_st_change = new STaskStatusChange();
            var service_request_task = new SRequest_Task();
            var service_request_st_change = new SRequestStatusChange();
            var service_request = new SRequest();

            var new_task = new Models.DTO.Task();
            var task_st_change = new Models.DTO.TaskStatusChange();
            var request_task = new Models.DTO.Request_Task();
            var request_st_change = new Models.DTO.RequestStatusChange();
            var request = new Models.DTO.Request();

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

            new_task.task_note = form["note"];
            new_task.address_id = id_adrc;
            Int32.TryParse(form["service_list"], out new_task.service_id);


            task_st_change.old_status = null;
            task_st_change.new_status = 1;
            int id_task = service_task.Insert(new_task);
            task_st_change.task_id = id_task;
            service_task_st_change.Insert(task_st_change);


            Int32.TryParse(form["request_list"], out request_task.request_id);
            Int32.TryParse(form["brigade_list"], out request_task.brigade_id);
            request_task.task_id = id_task;
            int res = service_request_task.Insert(request_task);

            //создана задача
            request_st_change = service_request_st_change.SelectLastStatus(request_task.request_id);
            request_st_change.old_status = request_st_change.new_status;
            request_st_change.new_status = 2;


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