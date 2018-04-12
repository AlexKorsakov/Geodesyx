using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geodesyx.Models.DTO
{
    public class Task : _Base
    {
        public int address_id;
        public int request;
        public string task_note;
        public int orderStatusChange_id;
        public int total_time;
    }
}