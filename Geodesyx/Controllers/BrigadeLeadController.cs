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
            var br = new SBrigade.BrigadeClient();
            Int32.TryParse(Request.Cookies["user"].Value, out brigade_id);
            //////
            try
            {
                brigade_id = br.SelectBrigadeID(brigade_id);

                if (brigade_id<=-1)
                    return View();
                var ids = new List<int>();
                
                var service_request_task = new SRequest_Task.Request_TaskClient();
                //id задач на бригаде
                
                ids = service_request_task.SelectTasksID(brigade_id);
                //задачи
                var service_tasks = new STask.TaskClient();
                
                ids = service_request_task.SelectTasksID(brigade_id);
                var service_brigade_task = new SBrigadeNewTasks.BrigadeNewTasksClient();
                var intersect = ids.Select(i => i).Intersect(service_tasks.SelectTaskIDs_ByStatus(1));
                ViewBag.Brigadeview = service_brigade_task.SelectIn(intersect.ToList());
                //Текущие задачи
                var service_brigade_task_inwork = new SBrigadeInWorkTasks.BrigadeInWorkTasksClient();
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
                var service_task_status_change = new STaskStatusChange.TaskStatusChangeClient();

                var task_st_change = new DTOlib.TaskStatusChange();
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
                var service_task_status_change = new STaskStatusChange.TaskStatusChangeClient();
                //связь статусы-заявки
                var service_request_status_change = new SRequestStatusChange.RequestStatusChangeClient();
                //задача
                var service_task = new STask.TaskClient();

                var task_st_change = new DTOlib.TaskStatusChange();
                task_st_change.old_status = 2;
                task_st_change.new_status = 3;
                task_st_change.task_id = Int32.Parse(collection["task_id"]);
                service_task_status_change.Insert(task_st_change);

                var request_st_change = new DTOlib.RequestStatusChange();
                request_st_change.old_status = 2;
                request_st_change.new_status = 3;
                request_st_change.request_id = Int32.Parse(collection["request_id"]);
                service_request_status_change.Insert(request_st_change);

                var task = new DTOlib.Task();
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
