using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geodesyx.Models.DTO
{
    public class VBrigadeNewTasks
    {
        public int request_id;
        public int task_id;
        public string request_name;
        public string request_description;
        public string service_name;
        public string task_note;        
        public string request_status_name;
        public DateTime change_date;
        public string address_name;
        public float adr_X;
        public float adr_Y;
        public int task_status_id;
    }
}