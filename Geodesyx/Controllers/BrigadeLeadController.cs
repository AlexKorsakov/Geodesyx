using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geodesyx.Service;

namespace Geodesyx.Controllers
{
    public class BrigadeLeadController : Controller
    {
        public bool Auth()
        {
            try
            {
                string user_type = Request.Cookies["user_type"].Value;
                return user_type == "3";
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

            int brigade_id = -1;
            var br = new SBrigade();
            Int32.TryParse(Request.Cookies["user"].Value, out brigade_id);
            //////
            try
            {
                brigade_id = br.SelectBrigadeID(brigade_id);

                if (brigade_id<=-1)
                    return View();
                var ids = new List<int>();
                
                var service_request_task = new SRequest_Task();
                //id задач на бригаде
                
                ids = service_request_task.SelectTasksID(brigade_id);
                //задачи
                var service_tasks = new STask();
                /*
                ViewBag.TaskList = service_tasks.SelectTasks(ids);
                //статусы задачи
                var service_task_status = new STaskStatus();
                ViewBag.TaskStatusList = service_task_status.SelectAll();
                //связь статусы-задачи
                var service_task_status_change = new STaskStatusChange();
                ids = new List<int>();
                foreach (var item in ViewBag.TaskList)
                    ids.Add(item.id);
                ViewBag.TaskStatusChangeList = service_task_status_change.Select(ids);
                */
                //задачи
                ids = service_request_task.SelectTasksID(brigade_id);
                var service_brigade_task = new SBrigadeNewTasks();
                var intersect = ids.Select(i => i).Intersect(service_tasks.SelectTaskIDs_ByStatus(1));
                ViewBag.Brigadeview = service_brigade_task.SelectIn(intersect.ToList());
                //Текущие задачи
                var service_brigade_task_inwork = new SBrigadeInWorkTasks();
                intersect = ids.Select(i => i).Intersect(service_tasks.SelectTaskIDs_ByStatus(2));
                ViewBag.Brigadeview_inwork = service_brigade_task_inwork.SelectIn(intersect.ToList());

                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }        

        [HttpPost]
        public ActionResult TaskToWork(FormCollection collection)
        {
            try
            {
                //связь статусы-задачи
                var service_task_status_change = new STaskStatusChange();

                var task_st_change = new Models.DTO.TaskStatusChange();
                task_st_change.old_status = 1;
                task_st_change.new_status = 2;
                task_st_change.task_id = Int32.Parse(collection["task_id"]);
                service_task_status_change.Insert(task_st_change);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult TaskClose(FormCollection collection)
        {
            try
            {
                //связь статусы-задачи
                var service_task_status_change = new STaskStatusChange();
                //связь статусы-заявки
                var service_request_status_change = new SRequestStatusChange();
                //задача
                var service_task = new STask();

                var task_st_change = new Models.DTO.TaskStatusChange();
                task_st_change.old_status = 2;
                task_st_change.new_status = 3;
                task_st_change.task_id = Int32.Parse(collection["task_id"]);
                service_task_status_change.Insert(task_st_change);

                var request_st_change = new Models.DTO.RequestStatusChange();
                request_st_change.old_status = 2;
                request_st_change.new_status = 3;
                request_st_change.request_id = Int32.Parse(collection["request_id"]);
                service_request_status_change.Insert(request_st_change);

                var task = new Models.DTO.Task();
                int id_task = service_task.Update(task_st_change.task_id, collection["note"], Int32.Parse(collection["total_time"]));

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
